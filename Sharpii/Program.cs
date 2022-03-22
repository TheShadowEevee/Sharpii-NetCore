﻿/* This file is part of Sharpii.
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
using System.Runtime.InteropServices;

namespace Sharpii
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Help();
                Environment.Exit(0);
            }

            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-QUIET":
                        BeQuiet.quiet = 1;
                        break;
                    case "-Q":
                        BeQuiet.quiet = 1;
                        break;
                    case "-LOTS":
                        BeQuiet.quiet = 3;
                        break;
                }
            }

            string Function = args[0].ToUpper();
            bool gotSomewhere = false;

            if (Function == "-H" || Function == "-HELP" || Function == "H" || Function == "HELP")
            {
                Help();
                gotSomewhere = true;
            }

            if (Function == "BNS")
            {
                BNS_Stuff.BNS(args);
                gotSomewhere = true;
            }

            if (Function == "WAD")
            {
                WAD_Stuff.WAD(args);
                gotSomewhere = true;
            }

            if (Function == "TPL")
            {
                TPL_Stuff.TPL(args);
                gotSomewhere = true;
            }

            if (Function == "U8")
            {
                U8_Stuff.U8(args);
                gotSomewhere = true;
            }

            if (Function == "IOS")
            {
                IOS_Stuff.IOS(args);
                gotSomewhere = true;
            }

            if (Function == "NUS" || Function == "NUSD")
            {
                NUS_Stuff.NUS(args);
                gotSomewhere = true;
            }

            if (Function == "SENDDOL" || Function == "SENDOL")
            {
                HBC_Stuff.SendDol(args);
                gotSomewhere = true;
            }

            if (Function == "SENDWAD")
            {
                bool cont = HBC_Stuff.SendWad_Check(args);
                if (cont == true) HBC_Stuff.SendWad(args);
                gotSomewhere = true;
            }

            if (Function == "ERRORS")
            {
                ERROR_Stuff.ERROR(args);
                gotSomewhere = true;
            }

            if (Function == "EXITCODES")
            {
                ERRORCODE_Stuff.ERRORCODE(args);
                gotSomewhere = true;
            }

            if (gotSomewhere == false)
            {
                //If the user gets here, they entered something wrong
                Console.WriteLine("ERROR: The argument {0} is invalid", args[0]);
                Console.WriteLine("Error: SHARPII_NET_CORE_MAIN_INVALID_ARG");
                if (OperatingSystem.Windows())
                {
                    Environment.Exit(0x00003E90);
                }
                else
                {
                    Environment.Exit(0x00000012);
                }
                return;
            }

            string temp = Path.GetTempPath() + "Sharpii.tmp";
            if (Directory.Exists(temp) == true)
                DeleteADir.DeleteDirectory(temp);

            Environment.Exit(0);
        }

        private static void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii .Net Core v{0} - Updated and Maintained by TheShadowEevee, originally by person66", ProgramVersion.version);
            Console.WriteLine("Using a modified version of libWiiSharp, originally made by leathl");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       ./Sharpii [function] [parameters] [-quiet | -q | -lots]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Functions:");
            Console.WriteLine("");
            Console.WriteLine("       BNS            Convert a wav to bns, or vice versa");
            Console.WriteLine("       WAD            Pack/Unpack/Edit a wad file");
            Console.WriteLine("       TPL            Convert a image to a tpl, or vice versa");
            Console.WriteLine("       U8             Pack/Unpack a U8 archive");
            Console.WriteLine("       IOS            Apply various patches to an IOS");
            Console.WriteLine("       NUSD           Download files from NUS");
            Console.WriteLine("       SendDol        Send a dol to the HBC over wifi");
            Console.WriteLine("       SendWad        Send a wad to the HBC over wifi");
            Console.WriteLine("       Errors         Get a Sharpii error's description");
            Console.WriteLine("       ExitCodes      List of all Sharpii exit codes");
            Console.WriteLine("");
            Console.WriteLine("       NOTE: To see more detailed descriptions of any of the above,");
            Console.WriteLine("             use 'Sharpii [function] -h'");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Global Arguments:");
            Console.WriteLine("");
            Console.WriteLine("       -quiet | -q    Try not to display any output");
            Console.WriteLine("       -lots          Display lots of output");
            Console.WriteLine("");
        }

        }
    }
public class DeleteADir
{
    public static bool DeleteDirectory(string target_dir)
    {
        bool result = false;

        string[] files = Directory.GetFiles(target_dir);
        string[] dirs = Directory.GetDirectories(target_dir);

        foreach (string file in files)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        foreach (string dir in dirs)
        {
            DeleteDirectory(dir);
        }

        Directory.Delete(target_dir, false);

        return result;
    }
}
public class BeQuiet
{
    //Little output = 1;
    //Normal output = 2;
    //Lots of output = 3;
    public static int quiet = 2;
}
public class ProgramVersion
{
    public static string version = "1.1.7";
}

public static class OperatingSystem
{
    //To check the running OS for Exit Code use.
    public static bool Windows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    public static bool Mac() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    public static bool GNULinux() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
}