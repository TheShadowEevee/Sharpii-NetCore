/* This file is part of Sharpii.
 * Copyright (C) 2013 Person66
 * Copyright (C) 2020 Sharpii-NetCore Contributors
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
using libWiiSharp;

namespace Sharpii
{
    partial class IOS_Stuff
    {
        public static void IOS(string[] args)
        {
            if (args.Length < 3)
            {
                IOS_help();
                return;
            }
            string input = args[1];
            string output = "";
            bool fs = false;
            bool es = false;
            bool np = false;
            bool vp = false;
            int slot = -1;
            int version = -1;

            //Check if file exists
            if (File.Exists(input) == false)
            {
                Console.WriteLine("ERROR: Unable to open file: {0}", input);
                Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                Console.WriteLine("Error: SHARPII_NET_CORE_IOS_FILE_ERR_01");
                if (OperatingSystem.Windows())
                {
                    Environment.Exit(0x00003E81);
                }
                else
                {
                    Environment.Exit(0x00000003);
                }
                return;
            }

            //Get parameters
            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-FS":
                        fs = true;
                        break;
                    case "-ES":
                        es = true;
                        break;
                    case "-NP":
                        np = true;
                        break;
                    case "-VP":
                        vp = true;
                        break;
                    case "-SLOT":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No slot set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_NO_SLOT_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E89);
                            }
                            else
                            {
                                Environment.Exit(0x0000000B);
                            }
                            return;
                        }
                        if (!int.TryParse(args[i + 1], out slot))
                        { 
                            Console.WriteLine("Invalid slot {0}...", args[i + 1]);
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_INVALID_SLOT_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8A);
                            }
                            else
                            {
                                Environment.Exit(0x0000000C);
                            }
                            return; 
                        }
                        if (slot < 3 || slot > 255)
                        { 
                            Console.WriteLine("Invalid slot {0}...", slot);
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_INVALID_SLOT_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8A);
                            }
                            else
                            {
                                Environment.Exit(0x0000000C);
                            }
                            return; 
                        }
                        break;
                    case "-S":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No slot set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_NO_SLOT_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E89);
                            }
                            else
                            {
                                Environment.Exit(0x0000000B);
                            }
                            return;
                        }
                        if (!int.TryParse(args[i + 1], out slot))
                        {
                            Console.WriteLine("Invalid slot {0}...", args[i + 1]);
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_INVALID_SLOT_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8A);
                            }
                            else
                            {
                                Environment.Exit(0x0000000C);
                            }
                            return;
                        }
                        if (slot < 3 || slot > 255)
                        {
                            Console.WriteLine("Invalid slot {0}...", slot);
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_INVALID_SLOT_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8A);
                            }
                            else
                            {
                                Environment.Exit(0x0000000C);
                            }
                            return;
                        }
                        break;
                    case "-V":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No version set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_NO_VERSION_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8B);
                            }
                            else
                            {
                                Environment.Exit(0x0000000D);
                            }
                            return;
                        }
                        if (!int.TryParse(args[i + 1], out version))
                        { 
                            Console.WriteLine("Invalid version {0}...", args[i + 1]);
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_INVALID_VERSION_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8C);
                            }
                            else
                            {
                                Environment.Exit(0x0000000E);
                            }
                            return; 
                        }
                        if (version < 0 || version > 65535)
                        { 
                            Console.WriteLine("Invalid version {0}...", version);
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_INVALID_VERSION_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8C);
                            }
                            else
                            {
                                Environment.Exit(0x0000000E);
                            }
                            return; 
                        }
                        break;
                    case "-O":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No output set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_IOS_NO_OUTPUT_01");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8D);
                            }
                            else
                            {
                                Environment.Exit(0x0000000F);
                            }
                            return;
                        }
                        output = args[i + 1];
                        break;
                }
            }

            //Main part (most of it was borrowed from PatchIOS)
            try
            {
                WAD ios = new WAD();
                ios.KeepOriginalFooter = true;

                if (BeQuiet.quiet > 2)
                    Console.Write("Loading File...");
                
                ios.LoadFile(input);
                
                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                //Check if WAD is an IOS
                if ((ios.TitleID >> 32) != 1 || (ios.TitleID & 0xffffffff) > 255 || (ios.TitleID & 0xffffffff) < 3)
                {
                    Console.WriteLine("Only IOS WADs can be patched...");
                    return;
                }

                IosPatcher patcher = new IosPatcher();

                patcher.LoadIOS(ref ios);

                //apply patches
                if (fs == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Applying Fakesigning patch");
                    patcher.PatchFakeSigning();
                }

                if (es == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Applying ES_Identify patch");
                    patcher.PatchEsIdentify();
                }

                if (np == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Applying NAND permissions patch");
                    patcher.PatchNandPermissions();
                }

                if (vp == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Applying Version patch");
                    patcher.PatchVP();
                }

                if (slot > -1 || version > -1)
                    ios.FakeSign = true;

                if (slot > -1)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Changing IOS slot to: {0}", slot);
                    ios.TitleID = (ulong)((1UL << 32) | (uint)slot);
                }

                if (version > -1)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Changing title version to: {0}", version);
                    ios.TitleVersion = (ushort)version;
                }

                //check if output was set
                if (output != "")
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Saving to file: {0}", output);
                    ios.Save(output);
                }
                else
                {
                    if (BeQuiet.quiet > 2)
                        Console.Write("Saving file...");

                    if (output != "")
                    {
                        if (output.Substring(output.Length - 4, 4).ToUpper() != ".WAD")
                            output = output + ".wad";
                    }

                    ios.Save(input);

                    if (BeQuiet.quiet > 2)
                        Console.Write("Done!\n");
                }
                if (BeQuiet.quiet > 1)
                    Console.WriteLine("Operation completed succesfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured, please try again");
                Console.WriteLine("");
                Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
                Console.WriteLine("Error: SHARPII_NET_CORE_IOS_UNKNOWN_01");
                if (OperatingSystem.Windows())
                {
                    Environment.Exit(0x00003E82);
                }
                else
                {
                    Environment.Exit(0x00000004);
                }
                return;
            }

            return;

        }

        public static void IOS_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii {0} - IOS - A tool by person66, using libWiiSharp.dll by leathl", ProgramVersion.version);
            Console.WriteLine("                      Code based off PatchIOS by leathl");
            Console.WriteLine("Sharpii .Net Core Port by TheShadowEevee");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       Sharpii.exe IOS input [-o output] [-fs] [-es] [-np] [-vp] [-s slot]");
            Console.WriteLine("                             [-v version]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Arguments:");
            Console.WriteLine("");
            Console.WriteLine("       input          The input file");
            Console.WriteLine("       -o output      The output file");
            Console.WriteLine("       -fs            Patch Fakesigning");
            Console.WriteLine("       -es            Patch ES_Identify");
            Console.WriteLine("       -np            Patch NAND Permissions");
            Console.WriteLine("       -vp            Add version patch");
            Console.WriteLine("       -s #           Change IOS slot to #");
            Console.WriteLine("       -v #           Change IOS version to #");
        }
    }
}