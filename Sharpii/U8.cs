﻿/* This file is part of Sharpii.
 * Copyright (C) 2013 Person66
 * Copyright (C) 2020-2022 Sharpii-NetCore Contributors
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

using libWiiSharp;
using System;
using System.IO;

namespace Sharpii
{
    partial class U8_Stuff
    {
        public static void U8(string[] args)
        {
            if (args.Length < 4)
            {
                U8_help();
                return;
            }

            //********************* Pack *********************
            if (args[1] == "-p")
            {
                Pack(args);
                return;
            }

            //********************* Unpack *********************
            if (args[1] == "-u")
            {
                Unpack(args);
                return;
            }

            //If tuser gets here, they entered something wrong
            Console.WriteLine("ERROR: The argument {0} is invalid", args[1]);
            Console.WriteLine("Error: SHARPII_NET_CORE_U8_INVALID_ARG");
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

        private static void Unpack(string[] args)
        {
            string input = args[2];
            string output = args[3];

            //Check if file exists
            if (File.Exists(input) == false)
            {
                Console.WriteLine("ERROR: Unable to open file: {0}", input);
                Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                Console.WriteLine("Error: SHARPII_NET_CORE_U8_FILE_ERR");
                return;
            }
            //Check if file is U8
            if (libWiiSharp.U8.IsU8(input) != true)
            {
                Console.WriteLine("ERROR: File {0} is not a U8 archive", input);
                Console.WriteLine("Error: SHARPII_NET_CORE_U8_NON_U8");
                if (OperatingSystem.Windows())
                {
                    Environment.Exit(0x00003E93);
                }
                else
                {
                    Environment.Exit(0x00000015);
                }
                return;
            }

            //Run main part, and check for exceptions
            try
            {
                //Load U8
                U8 U8file = new U8();

                if (BeQuiet.quiet > 2)
                    Console.Write("Loading file...");

                U8file.LoadFile(input);

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (BeQuiet.quiet > 2)
                    Console.Write("Extracting file...");

                U8file.Extract(output);

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (BeQuiet.quiet > 1)
                    Console.WriteLine("Operation completed succesfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured, please try again");
                Console.WriteLine("");
                Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
                Console.WriteLine("Error: SHARPII_NET_CORE_U8_UNKNOWN");
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
        }

        private static void Pack(string[] args)
        {
            //Setting up variables
            string input = args[2];
            string output = args[3];
            bool lz77 = false;
            bool imd5 = false;
            string imet = "";

            //Check if folder exists
            if (Directory.Exists(input) == false)
            {
                Console.WriteLine("ERROR: Unable to open Folder: {0}", input);
                Console.WriteLine("Either the folder doesn't exist, or Sharpii doesn't have permission to open it.");
                Console.WriteLine("Error: SHARPII_NET_CORE_U8_FOLDER_ERR");
                if (OperatingSystem.Windows())
                {
                    Environment.Exit(0x00003E94);
                }
                else
                {
                    Environment.Exit(0x00000016);
                }
                return;
            }

            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-LZ77":
                        lz77 = true;
                        break;
                    case "-IMD5":
                        imd5 = true;
                        break;
                    case "-IMET":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No title set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_U8_NO_TITLE");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E95);
                            }
                            else
                            {
                                Environment.Exit(0x00000017);
                            }
                            return;
                        }
                        imet = args[i + 1];
                        break;
                }
            }

            if (imd5 == true && imet != "")
            {
                Console.WriteLine("ERROR: Cannot use IMET and IMD5 at the same time.");
                Console.WriteLine("Error: SHARPII_NET_CORE_U8_TWO_HEADERS");
                if (OperatingSystem.Windows())
                {
                    Environment.Exit(0x00003E96);
                }
                else
                {
                    Environment.Exit(0x00000018);
                }
                return;
            }

            //Run main part, and check for exceptions
            try
            {
                U8 U8folder = new U8();

                if (BeQuiet.quiet > 2)
                    Console.Write("Loading folder...");

                U8folder.CreateFromDirectory(input);

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (imd5 == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Adding IMD5 Header");
                    U8folder.AddHeaderImd5();
                }

                if (imet != "")
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Adding IMET header with title: {0}", imet);
                    U8folder.AddHeaderImet(false, imet);
                }

                if (lz77 == true)
                {
                    //Yeah, I know this isnt where it actually compresses it
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Compressing U8 archive");
                    U8folder.Lz77Compress = true;
                }

                if (BeQuiet.quiet > 2)
                    Console.WriteLine("Saving file");

                U8folder.Save(output);

                if (BeQuiet.quiet > 1)
                    Console.WriteLine("Operation completed succesfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured, please try again");
                Console.WriteLine("");
                Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
                Console.WriteLine("Error: SHARPII_NET_CORE_U8_UNKNOWN");
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
        }

        public static void U8_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii .Net Core v{0} - Ported and Maintained by TheShadowEevee, originally by person66", ProgramVersion.version);
            Console.WriteLine("Using a modified version of libWiiSharp, originally made by leathl");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       ./Sharpii U8 [-p | -u] input output [arguments]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Arguments:");
            Console.WriteLine("");
            Console.WriteLine("       input          The input file/folder");
            Console.WriteLine("       output         The output file/folder");
            Console.WriteLine("       -p             Pack");
            Console.WriteLine("       -u             Unpack");
            Console.WriteLine("");
            Console.WriteLine("    Arguments for Packing:");
            Console.WriteLine("");
            Console.WriteLine("         -imet [title]  Pack with an IMET header (for 00000000.app)");
            Console.WriteLine("                        You MUST enter a channel title");
            Console.WriteLine("         -imd5          Pack with an IMD5 header (for Banner/Icon.bin)");
            Console.WriteLine("         -lz77          Compress with lz77");
        }
    }
}