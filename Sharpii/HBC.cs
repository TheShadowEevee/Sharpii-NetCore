﻿/* This file is part of Sharpii.
 * Copyright (C) 2013 Person66
 *
 * Sharpii is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Sharpii is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Sharpii. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Net;
using libWiiSharp;

namespace Sharpii
{
    partial class HBC_Stuff
    {
        public static void SendDol(string[] args)
        {
            if (args.Length < 2)
            {
                SendDol_help();
                return;
            }
            if (args[1].ToUpper() == "-H" || args[1].ToUpper() == "-HELP")
            {
                SendDol_help();
                return;
            }
            string input = "";
            string ip = "";
            string protocol = "JODI";
            string arguments = "";
            bool compress = true;
            bool saveip = false;
            bool noip = true;

            //Get parameters
            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-IP":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No ip set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_HBC_NO_IP_01");
                            Environment.Exit(0x00000643);
                            return;
                        }
                        ip = args[i + 1];
                        noip = false;
                        break;
                    case "-SAVEIP":
                        saveip = true;
                        break;
                    case "-DOL":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No dol set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_HBC_NO_DOL_01");
                            Environment.Exit(0x00000644);
                            return;
                        }
                        input = args[i + 1];
                        //Check if file exists
                        if (File.Exists(input) == false)
                        {
                            Console.WriteLine("ERROR: Unable to open file: {0}", input);
                            Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                            Console.WriteLine("Error: SHARPII_NET_CORE_HBC_FILE_ERR_01");
                            Environment.Exit(0x00000641);
                            return;
                        }

                        if (i + 1 < args.Length)
                        {
                            for (int n = i + 2; n < args.Length; n++)
                            {
                                arguments = arguments + "\x0000";
                                arguments = arguments + args[n];
                            }
                        }
                        break;
                    case "-NOCOMP":
                        compress = false;
                        break;
                    case "-OLD":
                        protocol = "HAXX";
                        break;
                }
            }

            //Run main part, and check for exceptions
            try
            {
                if (ip != "" && saveip == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Saving IP");
                    Environment.SetEnvironmentVariable("SharpiiIP", ip, EnvironmentVariableTarget.Machine);
                }

                if (String.IsNullOrEmpty(ip))
                    ip = Environment.GetEnvironmentVariable("SharpiiIP", EnvironmentVariableTarget.User);
                if (String.IsNullOrEmpty(ip))
                    ip = Environment.GetEnvironmentVariable("SharpiiIP", EnvironmentVariableTarget.Machine);
                if (String.IsNullOrEmpty(ip))
                {
                    Console.WriteLine("ERROR: No IP set");
                    Console.WriteLine("Error: SHARPII_NET_CORE_HBC_NO_IP_01");
                    Environment.Exit(0x00000643);
                    return;
                }
                if (noip == true && BeQuiet.quiet > 2)
                    Console.WriteLine("No IP set, using {0}", ip);
                
                libWiiSharp.Protocol proto = Protocol.JODI;

                if (BeQuiet.quiet > 2 && protocol == "HAXX")
                    Console.WriteLine("Using old protocol");

                if (protocol == "HAXX")
                    proto = Protocol.HAXX;

                if (BeQuiet.quiet > 2)
                    Console.Write("Loading File...");

                HbcTransmitter file = new HbcTransmitter(proto, ip);
                
                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");


                if (BeQuiet.quiet > 2 && compress == true)
                    Console.Write("Compressing File...");
                
                file.Compress = compress;
                
                if (BeQuiet.quiet > 2 && compress == true)
                    Console.Write("Done!\n");

                if (BeQuiet.quiet > 1)
                    Console.Write("Sending file...");

                file.TransmitFile(Path.GetFileName(input) + arguments, File.ReadAllBytes(input));

                if (BeQuiet.quiet > 1)
                    Console.Write("Done!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured, please try again");
                Console.WriteLine("");
                Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
                Console.WriteLine("Error: SHARPII_NET_CORE_HBC_UNKNOWN_01");
                Environment.Exit(0x00000642);
                return;
            }

            return;

        }

        public static bool SendWad_Check(string[] args)
        {
            if (args.Length < 2)
            {
                SendWad_help();
                return false;
            }
            if (args[1].ToUpper() == "-H" || args[1].ToUpper() == "-HELP")
            {
                SendWad_help();
                return false;
            }

            if (!File.Exists(Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "WadInstaller.dll")))
            {
                Console.WriteLine("ERROR: WadInstaller.dll not found");
                Console.WriteLine("This should not appear on the .Net Core port.");
                Console.WriteLine("If you see this, report how you got here on https://github.com/TheShadowEevee/Sharpii-NetCore/issues.");
                Console.WriteLine("Error: SHARPII_NET_CORE_HBC_MISSING_DLL_WADINSTALLER_01");
                Environment.Exit(0x00000645);
            }

            return true;
        }

        public static void SendWad(string[] args)
        {
            string input = "";
            string ip = "";
            string ios = "";
            string protocol = "JODI";
            bool ahb = false;
            bool saveip = false;
            bool noip = true;

            //Get parameters
            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-IOS":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No ios set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_HBC_NO_IOS_01");
                            Environment.Exit(0x00000646);
                            return;
                        }
                        ios = args[i + 1];
                        if (!(Convert.ToInt32(ios) >= 3 && Convert.ToInt32(ios) <= 255))
                        {
                            Console.WriteLine("ERROR: Invalid IOS number");
                            Console.WriteLine("Error: SHARPII_NET_CORE_HBC_INVALID_IOS_01");
                            Environment.Exit(0x00000647);
                            return;
                        }
                        break;
                    case "-AHB":
                        ahb = true;
                        break;
                    case "-IP":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No ip set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_HBC_NO_IP_01");
                            Environment.Exit(0x00000643);
                            return;
                        }
                        ip = args[i + 1];
                        noip = false;
                        break;
                    case "-SAVEIP":
                        saveip = true;
                        break;
                    case "-WAD":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No WAD set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_HBC_NO_WAD_01");
                            Environment.Exit(0x00000648);
                            return;
                        }
                        input = args[i + 1];
                        //Check if file exists
                        if (File.Exists(input) == false)
                        {
                            Console.WriteLine("ERROR: Unable to open file: {0}", input);
                            Console.WriteLine("Error: SHARPII_NET_CORE_BNS_FILE_ERR_01");
                            Environment.Exit(0x00000641);
                            return;
                        }
                        break;
                    case "-OLD":
                        protocol = "HAXX";
                        break;
                }
            }

            //Run main part, and check for exceptions
            try
            {
                if (ip != "" && saveip == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Saving IP");
                    Environment.SetEnvironmentVariable("SharpiiIP", ip, EnvironmentVariableTarget.Machine);
                }

                if (ahb == true || ios == "")
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Using AHBPROT");
                    ios = "0";
                }

                if (String.IsNullOrEmpty(ip))
                    ip = Environment.GetEnvironmentVariable("SharpiiIP", EnvironmentVariableTarget.User);
                if (String.IsNullOrEmpty(ip))
                    ip = Environment.GetEnvironmentVariable("SharpiiIP", EnvironmentVariableTarget.Machine);
                if (String.IsNullOrEmpty(ip))
                {
                    Console.WriteLine("ERROR: No IP set");
                    Console.WriteLine("Error: SHARPII_NET_CORE_HBC_NO_IP_01");
                    Environment.Exit(0x00000643);
                    return;
                }
                if (noip == true && BeQuiet.quiet > 2)
                    Console.WriteLine("No IP set, using {0}", ip);

                libWiiSharp.Protocol proto = Protocol.JODI;

                if (BeQuiet.quiet > 2 && protocol == "HAXX")
                    Console.WriteLine("Using old protocol");

                if (protocol == "HAXX")
                    proto = Protocol.HAXX;

                if (BeQuiet.quiet > 2)
                    Console.Write("Loading File...");

                HbcTransmitter file = new HbcTransmitter(proto, ip);
                byte[] Installer = WadInstaller.InstallerHelper.CreateInstaller(input, (byte)Convert.ToInt32(ios)).ToArray();

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (BeQuiet.quiet > 1)
                    Console.Write("Sending file...");

                file.TransmitFile("WadInstaller.dol", Installer);

                if (BeQuiet.quiet > 1)
                    Console.Write("Done!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured, please try again");
                Console.WriteLine("");
                Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
                Console.WriteLine("Error: SHARPII_NET_CORE_HBC_UNKNOWN_01");
                Environment.Exit(0x00000642);
                return;
            }

            return;

        }

        private static void SendDol_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii {0} - SendDol - A tool by person66, using libWiiSharp.dll by leathl", ProgramVersion.version);
            Console.WriteLine("Sharpii .Net Core Port by TheShadowEevee");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       Sharpii.exe SendDol -ip ip_adress [-old] [-nocomp] [-saveip]");
            Console.WriteLine("                            -dol file [args]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Arguments:");
            Console.WriteLine("");
            Console.WriteLine("       -dol file      The dol file to send");
            Console.WriteLine("       -ip ip_adress  The IP address of your wii");
            Console.WriteLine("       -saveip        Save entered IP address for future use");
            Console.WriteLine("       -old           Use for the old (1.0.4 and below) HBC");
            Console.WriteLine("       -nocomp        Disable compression");
            Console.WriteLine("       args           Dol arguments");
            Console.WriteLine("");
            Console.WriteLine("       NOTE: Any arguments after '-dol file' will be sent as dol");
            Console.WriteLine("             arguments");
        }

        public static void SendWad_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii {0} - SendWad - A tool by person66, using libWiiSharp.dll by leathl,", ProgramVersion.version);
            Console.WriteLine("                          and CRAP's installer by WiiCrazy/I.R.on");
            Console.WriteLine("Sharpii .Net Core Port by TheShadowEevee");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       Sharpii.exe SendWad -ip ip_adress -wad file [-ios IOS | -ahb] [-old]");
            Console.WriteLine("                           [-nocomp] [-saveip]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Arguments:");
            Console.WriteLine("");
            Console.WriteLine("       -dol file      The dol file to send");
            Console.WriteLine("       -ip ip_adress  The IP address of your wii");
            Console.WriteLine("       -ios ios       The ios to use to install the wad");
            Console.WriteLine("       -ahb           Use HW_AHBPROT to install the wad");
            Console.WriteLine("       -saveip        Save entered IP address for future use");
            Console.WriteLine("       -old           Use for the old (1.0.4 and below) HBC");
            Console.WriteLine("       -nocomp        Disable compression");
            Console.WriteLine("");
            Console.WriteLine("       NOTE: WAD files must be less than 8MB large");
        }
    }
}