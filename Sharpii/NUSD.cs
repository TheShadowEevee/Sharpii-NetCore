/* This file is part of Sharpii.
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
using System.Collections.Generic;
using libWiiSharp;

namespace Sharpii
{
    partial class NUS_Stuff
    {
        public static void NUS(string[] args)
        {
            if (args.Length < 2)
            {
                NUS_help();
                return;
            }
            if (args[1].ToUpper() == "-H" || args[1].ToUpper() == "-HELP")
            {
                NUS_help();
                return;
            }

            //Set up variables
            string id = "";
            string content = "";
            string version = "";
            int intver = -1;
            string output = "";
            bool local = false;
            List<StoreType> store = new List<StoreType>();
            bool entered = false;
            bool wad = false;
            bool NoOut = false;
            string ios = "";
            string temp = Path.GetTempPath() + "Sharpii.tmp";

            //Get arguments
            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-ALL":
                        store.Add(StoreType.All);
                        entered = true;
                        break;
                    case "-WAD":
                        store.Add(StoreType.WAD);
                        entered = true;
                        break;
                    case "-ENCRYPT":
                        store.Add(StoreType.EncryptedContent);
                        entered = true;
                        break;
                    case "-ENCRYPTED":
                        store.Add(StoreType.EncryptedContent);
                        entered = true;
                        break;
                    case "-DECRYPT":
                        store.Add(StoreType.DecryptedContent);
                        entered = true;
                        break;
                    case "-DECRYPTED":
                        store.Add(StoreType.DecryptedContent);
                        entered = true;
                        break;
                    case "-LOCAL":
                        local = true;
                        break;
                    case "-V":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No version set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_VERSION_01");
                            Environment.Exit(0x00003E8B);
                            return;
                        }
                        version = args[i + 1];
                        if (version.ToUpper() == "LATEST")
                            break;
                        if (!int.TryParse(version, out intver))
                        {
                            Console.WriteLine("Invalid version {0}...", args[i + 1]);
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_INVALID_VERSION_01");
                            Environment.Exit(0x00003E8C);
                            return;
                        }
                        if (intver < 0 || intver > 65535)
                        {
                            Console.WriteLine("Invalid version {0}...", version);
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_INVALID_VERSION_01");
                            Environment.Exit(0x00003E8C);
                            return;
                        }
                        break;
                    case "-VERSION":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No version set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_VERSION_01");
                            Environment.Exit(0x00003E8B);
                            return;
                        }
                        version = args[i + 1];
                        if (version.ToUpper() == "LATEST")
                            break;
                        if (!int.TryParse(version, out intver))
                        {
                            Console.WriteLine("Invalid version {0}...", args[i + 1]);
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_INVALID_VERSION_01");
                            Environment.Exit(0x00003E8C);
                            return;
                        }
                        if (intver < 0 || intver > 65535)
                        {
                            Console.WriteLine("Invalid version {0}...", version);
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_INVALID_VERSION_01");
                            Environment.Exit(0x00003E8C);
                            return;
                        }
                        break;
                    case "-O":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No output set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_OUTPUT_01");
                            Environment.Exit(0x00003E8D);
                            return;
                        }
                        output = args[i + 1];
                        break;
                    case "-ID":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No ID specified");
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_ID_01");
                            Environment.Exit(0x00003E8E);
                            return;
                        }
                        id = args[i + 1];
                        break;
                    case "-IOS":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No IOS specified");
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_IOS_01");
                            Environment.Exit(0x00003E86);
                            return;
                        }
                        id = "00000001000000" + Convert.ToInt32(args[i + 1]).ToString("X2");
                        break;
                    case "-SINGLE":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No ID specified");
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_ID_01");
                            Environment.Exit(0x00003E8E);
                            return;
                        }
                        content = args[i + 1];
                        break;
                    case "-S":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No ID specified");
                            Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_ID_01");
                            Environment.Exit(0x00003E8E);
                            return;
                        }
                        content = args[i + 1];
                        break;
                }
            }

            //Error checking & stuff
            if (id == "")
            {
                Console.WriteLine("ERROR: No ID specified");
                Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_NO_ID_01");
                Environment.Exit(0x00003E8E);
                return;
            }

            if (version == "")
            {
                if (BeQuiet.quiet > 2)
                    Console.WriteLine("No version specified, using latest", version);
                version = "LATEST";
            }

            try
            {
                if (version.ToUpper() == "LATEST")
                {
                    //Grab the TMD and get the latest version
                    NusClient grabtmd = new NusClient();
                    TMD tmd = grabtmd.DownloadTMD(id, "");
                    version = tmd.TitleVersion.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Title ID must be 16 characters long!")
                {
                    Console.WriteLine("");
                    Console.WriteLine("The ID needs to be 16 Characters.");
                    Console.WriteLine("");
                    Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_BAD_ID_01");
                    Console.WriteLine("");
                    Environment.Exit(0x00003E9C);
                    return;
                }
                if (ex.Message == "The remote server returned an error: (404) Not Found.")
                {
                    Console.WriteLine("");
                    Console.WriteLine("The ID is not a valid title ID");
                    Console.WriteLine("");
                    Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_BAD_ID_01");
                    Console.WriteLine("");
                    Environment.Exit(0x00003E9C);
                    return;
                }
            }
            if (BeQuiet.quiet > 2)
                Console.WriteLine("Found latest version: v{0}", version);

            if (entered == false) //Will only be false if no store type argument was given
            {
                store.Add(StoreType.All);
                if (BeQuiet.quiet > 2)
                    Console.WriteLine("No store type specified, using all");
            }

            if (id.Length == 16 && Convert.ToInt32(id.Substring(14, 2), 16) >= 3 && Convert.ToInt32(id.Substring(14, 2), 16) <= 255 && id.Substring(0, 14) == "00000001000000")
                ios = "IOS" + Convert.ToInt32(id.Substring(14, 2), 16) + "-64-" + version + ".wad";

            if ((((output.Length >= 4 && output.Substring(output.Length - 4, 4).ToUpper() == ".WAD") || output == "") && Array.IndexOf(store.ToArray(), StoreType.WAD) != -1 && store.ToArray().Length == 1) || (output == "" && ios != "" && Array.IndexOf(store.ToArray(), StoreType.WAD) != -1 && store.ToArray().Length == 1))
            {
                wad = true;
                if (Directory.Exists(temp) == true)
                    DeleteADir.DeleteDirectory(temp);                

                Directory.CreateDirectory(temp);
            }

            if (output == "")
            {
                NoOut = true;
                output = ios == "" ? id + "v" + version : ios.Substring(0, ios.Length - 4);
                if (BeQuiet.quiet > 2)
                    Console.WriteLine("No output specified, using {0}", output);
            }

            //Main part, catches random/unexpected exceptions
            try
            {
                NusClient nus = new NusClient();

                if (local == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Using local files if present...");
                    nus.UseLocalFiles = true;
                }


                if (content != "")
                {
                    if (BeQuiet.quiet > 1)
                        Console.Write("Downloading content...");

                    nus.DownloadSingleContent(id, version, content, output);

                    if (BeQuiet.quiet > 1)
                        Console.Write("Done!\n");
                }
                else
                {
                    if (BeQuiet.quiet > 1)
                        Console.Write("Downloading title...");
                    
                    string realout = output;
                    if (wad == true)
                        output = temp;
                    
                    nus.DownloadTitle(id, version, output, store.ToArray());

                    WadIosNamingStuff(wad, temp, id, version, ios, NoOut, output, realout);

                    if (BeQuiet.quiet > 1)
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
                Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_UNKNOWN_01");
                Environment.Exit(0x00003E82);
                return;
            }

            return;

        }

        private static void WadIosNamingStuff(bool wad, string temp, string id, string version, string ios, bool NoOut, string output, string realout)
        {
            if (wad == true)
            {
                if (!File.Exists(Path.Combine(temp, id + "v" + version + ".wad")))
                {
                    Console.WriteLine("ERROR: Can't find WAD");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_FILE_ERR_01");
                    Environment.Exit(0x00003E81);
                    return;
                }
                if (ios != "" && NoOut == true)
                {
                    int index = realout.LastIndexOf("\\") > realout.LastIndexOf("/") ? realout.LastIndexOf("\\") : realout.LastIndexOf("/");
                    if (File.Exists(realout.Substring(0, index + 1) + ios))
                        File.Delete(realout.Substring(0, index + 1) + ios);
                    File.Move(Path.Combine(temp, id + "v" + version + ".wad"), realout.Substring(0, index + 1) + ios);
                }
                else if (ios == "" && NoOut == true)
                {
                    if (File.Exists(realout + ".wad"))
                        File.Delete(realout + ".wad");
                    File.Move(Path.Combine(temp, id + "v" + version + ".wad"), realout + ".wad");
                }
                else
                {
                    if (File.Exists(realout))
                        File.Delete(realout);
                    File.Move(Path.Combine(temp, id + "v" + version + ".wad"), realout);
                }
                DeleteADir.DeleteDirectory(temp);
            }
            else if (ios != "")
            {
                if (output.Substring(output.Length - 1, 1) == "\\" || output.Substring(output.Length - 1, 1) == "/")
                    output = output.Substring(output.Length - 1, 1);
                if (File.Exists(Path.Combine(output, id + "v" + version + ".wad")))
                {
                    if (File.Exists(Path.Combine(output, ios)))
                        File.Delete(Path.Combine(output, ios));
                    File.Move(Path.Combine(output, id + "v" + version + ".wad"), Path.Combine(output, ios));
                }
            }
        }

        public static void NUS_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii {0} - NUSD - A tool by person66, using libWiiSharp.dll by leathl", ProgramVersion.version);
            Console.WriteLine("Sharpii .Net Core Port by TheShadowEevee");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       Sharpii.exe NUSD [-id titleID | -ios IOS] [-v version] [-o otput] [-all]");
            Console.WriteLine("                        [-wad] [-decrypt] [-encrypt] [-local] [-s content]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Arguments:");
            Console.WriteLine("");
            Console.WriteLine("       -id titleID    [required] The Title ID of the file you wish to download");
            Console.WriteLine("       -v version     [required] The version of the file you wish to download");
            Console.WriteLine("                      NOTE: Use 'latest' to get the latest version");
            Console.WriteLine("       -ios IOS       The IOS you wish to download. This is an alternative to");
            Console.WriteLine("                      '-id', use one or the other, but not both.");
            Console.WriteLine("       -o output      Folder to output the files to");
            Console.WriteLine("       -local         Use local files if present");
            Console.WriteLine("       -s content     Download a single content from the file");
            Console.WriteLine("                      NOTE: When using this, output MUST have a path and a");
            Console.WriteLine("                      filename. For current directory use '.\\[filename]'");
            Console.WriteLine("       -all           Create and keep encrypted, decrypted, and WAD versions");
            Console.WriteLine("                      of the file you wish to download");
            Console.WriteLine("       -wad           Keep only the WAD version of the file you wish to");
            Console.WriteLine("                      download");
            Console.WriteLine("       -decrypt       Keep only the decrypted contents of the file you wish to");
            Console.WriteLine("                      download");
            Console.WriteLine("       -encrypt       Keep only the encrypted contents of the file you wish to");
            Console.WriteLine("                      download");
        }
    }
}