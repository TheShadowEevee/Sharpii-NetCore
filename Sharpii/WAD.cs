/* This file is part of Sharpii.
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
    partial class WAD_Stuff
    {
        public static int ExceptionListRan = 0;
        public static void WAD(string[] args)
        {
            if (args.Length < 3)
            {
                WAD_help();
                return;
            }

            //********************* PACK *********************
            if (args[1] == "-p")
            {
                if (args.Length < 4)
                {
                    WAD_help();
                    return;
                }

                Editor(args, false);
                return;
            }

            //********************* UNPACK *********************
            if (args[1] == "-u")
            {
                if (args.Length < 4)
                {
                    WAD_help();
                    return;
                }

                Unpack(args);
                return;
            }

            //********************* EDIT *********************
            if (args[1] == "-e")
            {
                if (args.Length < 4)
                {
                    WAD_help();
                    return;
                }

                Editor(args, true);
                return;
            }

            //********************* INFO *********************
            if (args[1] == "-i")
            {
                Info(args);
                return;
            }

            //If tuser gets here, they entered something wrong
            Console.WriteLine("ERROR: The argument {0} is invalid", args[1]);
            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_INVALID_ARG");
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

        private static void Info(string[] args)
        {
            string input = args[2];
            string output = "";
            bool titles = false;

            //Check if file exists
            if (File.Exists(input) == false)
            {
                Console.WriteLine("ERROR: Unable to open file: {0}", input);
                Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FILE_ERR");
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

            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-O":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No output set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_OUTPUT");
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
                    case "-OUTPUT":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No output set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_OUTPUT");
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
                    case "-TITLES":
                        titles = true;
                        break;
                }
            }

            try
            {
                WAD wad = new WAD();

                if (BeQuiet.quiet > 2)
                    Console.Write("Loading file...");

                wad.LoadFile(input);

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (BeQuiet.quiet > 1 && output == "")
                {
                    Console.WriteLine("WAD Info:");
                    Console.WriteLine("");
                    if (titles == false)
                        Console.WriteLine("Title: {0}", wad.ChannelTitles[1]);
                    else
                    {
                        Console.WriteLine("Titles:\n");
                        Console.WriteLine("   Japanese: {0}", wad.ChannelTitles[0]);
                        Console.WriteLine("   English: {0}", wad.ChannelTitles[1]);
                        Console.WriteLine("   German: {0}", wad.ChannelTitles[2]);
                        Console.WriteLine("   French: {0}", wad.ChannelTitles[3]);
                        Console.WriteLine("   Spanish: {0}", wad.ChannelTitles[4]);
                        Console.WriteLine("   Italian: {0}", wad.ChannelTitles[5]);
                        Console.WriteLine("   Dutch: {0}", wad.ChannelTitles[6]);
                        Console.WriteLine("   Korean: {0}\n", wad.ChannelTitles[7]);
                    }
                    Console.WriteLine("Title ID: {0}", wad.UpperTitleID);
                    Console.WriteLine("Full Title ID: {0}", wad.TitleID.ToString("X16").Substring(0, 8) + "-" + wad.TitleID.ToString("X16")[8..]);
                    Console.WriteLine("IOS: {0}", ((int)wad.StartupIOS).ToString());
                    Console.WriteLine("Region: {0}", wad.Region);
                    Console.WriteLine("Version: {0}", wad.TitleVersion);
                    Console.WriteLine("Blocks: {0}", wad.NandBlocks);
                }
                else
                {
                    if (BeQuiet.quiet > 2)
                        Console.Write("Saving file...");

                    if (output.Substring(output.Length - 4, 4).ToUpper() != ".TXT")
                        output += ".txt";

                    TextWriter txt = new StreamWriter(output);
                    txt.WriteLine("WAD Info:");
                    txt.WriteLine("");
                    if (titles == false)
                        txt.WriteLine("Title: {0}", wad.ChannelTitles[1]);
                    else
                    {
                        txt.WriteLine("Titles:");
                        txt.WriteLine("     Japanese: {0}", wad.ChannelTitles[0]);
                        txt.WriteLine("     English: {0}", wad.ChannelTitles[1]);
                        txt.WriteLine("     German: {0}", wad.ChannelTitles[2]);
                        txt.WriteLine("     French: {0}", wad.ChannelTitles[3]);
                        txt.WriteLine("     Spanish: {0}", wad.ChannelTitles[4]);
                        txt.WriteLine("     Italian: {0}", wad.ChannelTitles[5]);
                        txt.WriteLine("     Dutch: {0}", wad.ChannelTitles[6]);
                        txt.WriteLine("     Korean: {0}", wad.ChannelTitles[7]);
                    }
                    txt.WriteLine("Title ID: {0}", wad.UpperTitleID);
                    txt.WriteLine("Full Title ID: {0}", wad.TitleID.ToString("X16").Substring(0, 8) + "-" + wad.TitleID.ToString("X16")[8..]);
                    txt.WriteLine("IOS: {0}", ((int)wad.StartupIOS).ToString());
                    txt.WriteLine("Region: {0}", wad.Region);
                    txt.WriteLine("Version: {0}", wad.TitleVersion);
                    txt.WriteLine("Blocks: {0}", wad.NandBlocks);
                    txt.Close();

                    if (BeQuiet.quiet > 2)
                        Console.Write("Done!\n");

                    if (BeQuiet.quiet > 1)
                        Console.WriteLine("Operation completed succesfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured, please try again");
                Console.WriteLine("");
                Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
                Console.WriteLine("Error: SHARPII_NET_CORE_WAD_UNKNOWN");
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

        private static void Editor(string[] args, bool edit)
        {
            //Setting up variables
            string input = args[2];
            string output = args[3];
            string id = "";
            int ios = -1;
            string title = "";
            string lwrid = "";
            bool fake = false;
            string sound = "";
            string banner = "";
            string icon = "";
            string app = "";

            //Check if file/folder exists
            if (edit == true)
                if (File.Exists(input) == false)
                {
                    Console.WriteLine("ERROR: Unable to open file: {0}", input);
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FILE_ERR");
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
            if (edit == false)
                if (Directory.Exists(input) == false)
                {
                    Console.WriteLine("ERROR: Unable to open folder: {0}", input);
                    Console.WriteLine("Either the folder doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FOLDER_ERR");
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
                    case "-F":
                        fake = true;
                        break;
                    case "-ID":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No ID set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_ID");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E8E);
                            }
                            else
                            {
                                Environment.Exit(0x00000010);
                            }
                            return;
                        }
                        id = args[i + 1];
                        if (id.Length < 4)
                        {
                            Console.WriteLine("ERROR: ID too short");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_SHORT_ID");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E97);
                            }
                            else
                            {
                                Environment.Exit(0x00000019);
                            }
                            return;
                        }
                        id = id.Substring(0, 4);
                        break;
                    case "-TYPE":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No type set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_TYPE");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E98);
                            }
                            else
                            {
                                Environment.Exit(0x0000001A);
                            }
                            return;
                        }
                        lwrid = args[i + 1].ToUpper();
                        if (lwrid != "CHANNEL" && lwrid != "DLC" && lwrid != "GAMECHANNEL" && lwrid != "HIDDENCHANNELS" && lwrid != "SYSTEMCHANNELS" && lwrid != "SYSTEMTITLES")
                        {
                            Console.WriteLine("ERROR: Unknown WAD type: {0}", args[i + 1]);
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_UNKNOWN_TYPE");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E99);
                            }
                            else
                            {
                                Environment.Exit(0x0000001B);
                            }
                            return;
                        }
                        break;
                    case "-IOS":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No type set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_TYPE");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E98);
                            }
                            else
                            {
                                Environment.Exit(0x0000001A);
                            }
                            return;
                        }
                        if (!int.TryParse(args[i + 1], out ios))
                        {
                            Console.WriteLine("Invalid slot {0}...", args[i + 1]);
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_INVALID_SLOT");
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
                        if (ios < 0 || ios > 255)
                        {
                            Console.WriteLine("Invalid slot {0}...", ios);
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_INVALID_SLOT");
                            Environment.Exit(0x00003E8A);
                            return;
                        }
                        break;
                    case "-TITLE":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No title set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_TITLE");
                            Environment.Exit(0x00003E95);
                            return;
                        }
                        title = args[i + 1];
                        break;
                    case "-SOUND":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No sound set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_SOUND");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E9A);
                            }
                            else
                            {
                                Environment.Exit(0x0000001C);
                            }
                            return;
                        }
                        sound = args[i + 1];
                        if (File.Exists(sound) == false)
                        {
                            Console.WriteLine("ERROR: Unable to find sound wad");
                            Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FILE_ERR");
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
                        break;
                    case "-BANNER":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No banner set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_BANNER");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E9B);
                            }
                            else
                            {
                                Environment.Exit(0x0000001D);
                            }
                            return;
                        }
                        banner = args[i + 1];
                        if (File.Exists(banner) == false)
                        {
                            Console.WriteLine("ERROR: Unable to find banner wad");
                            Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FILE_ERR");
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
                        break;
                    case "-ICON":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No sound set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_SOUND");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E9A);
                            }
                            else
                            {
                                Environment.Exit(0x0000001C);
                            }
                            return;
                        }
                        icon = args[i + 1];
                        if (File.Exists(icon) == false)
                        {
                            Console.WriteLine("ERROR: Unable to find icon wad");
                            Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FILE_ERR");
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
                        break;
                    case "-DOL":
                        if (i + 1 >= args.Length)
                        {
                            Console.WriteLine("ERROR: No dol set");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_NO_DOL");
                            if (OperatingSystem.Windows())
                            {
                                Environment.Exit(0x00003E84);
                            }
                            else
                            {
                                Environment.Exit(0x00000006);
                            }
                            return;
                        }
                        app = args[i + 1];
                        if (File.Exists(app) == false)
                        {
                            Console.WriteLine("ERROR: Unable to find dol wad/file");
                            Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                            Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FILE_ERR");
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
                        break;
                }
            }

            //Run main part, and check for exceptions
            try
            {
                WAD wad = new WAD();

                if (edit == true)
                {
                    if (BeQuiet.quiet > 2)
                        Console.Write("Loading file...");
                    wad.LoadFile(input);
                }
                else
                {
                    if (BeQuiet.quiet > 2)
                        Console.Write("Loading folder...");
                    wad.CreateNew(input);
                }

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (sound != "" || banner != "" || icon != "" || app != "")
                {
                    string temp = Path.GetTempPath() + "Sharpii.tmp";
                    if (Directory.Exists(temp) == true)
                        DeleteADir.DeleteDirectory(temp);

                    Directory.CreateDirectory(temp);

                    wad.Unpack(Path.Combine(temp, "main"));
                    U8 u = new U8();
                    u.LoadFile(Path.Combine(temp, "main", "00000000.app"));
                    u.Extract(Path.Combine(temp, "main", "00000000"));

                    WAD twad = new WAD();

                    if (sound != "")
                    {
                        if (BeQuiet.quiet > 2)
                            Console.Write("Grabbing sound...");

                        twad.LoadFile(sound);
                        twad.Unpack(Path.Combine(temp + "sound"));
                        U8 tu = new U8();
                        tu.LoadFile(Path.Combine(temp, "sound", "00000000.app"));
                        tu.Extract(Path.Combine(temp, "sound", "00000000"));

                        File.Copy(Path.Combine(temp, "sound", "00000000", "meta", "sound.bin"), Path.Combine(temp, "main", "00000000", "meta", "sound.bin"), true);

                        if (BeQuiet.quiet > 2)
                            Console.Write("Done!\n");
                    }
                    if (banner != "")
                    {
                        if (BeQuiet.quiet > 2)
                            Console.Write("Grabbing banner...");

                        twad.LoadFile(banner);
                        twad.Unpack(Path.Combine(temp, "banner"));
                        U8 tu = new U8();
                        tu.LoadFile(Path.Combine(temp, "banner", "00000000.app"));
                        tu.Extract(Path.Combine(temp, "banner", "00000000"));

                        File.Copy(Path.Combine(temp, "banner", "00000000", "meta", "banner.bin"), Path.Combine(temp, "main", "00000000", "meta", "banner.bin"), true);

                        if (BeQuiet.quiet > 2)
                            Console.Write("Done!\n");
                    }
                    if (icon != "")
                    {
                        if (BeQuiet.quiet > 2)
                            Console.Write("Grabbing icon...");

                        twad.LoadFile(icon);
                        twad.Unpack(Path.Combine(temp, "icon"));
                        U8 tu = new U8();
                        tu.LoadFile(Path.Combine(temp, "icon", "00000000.app"));
                        tu.Extract(Path.Combine(temp, "icon", "00000000"));

                        File.Copy(Path.Combine(temp, "icon", "00000000", "meta", "icon.bin"), Path.Combine(temp, "main", "00000000", "meta", "icon.bin"), true);

                        if (BeQuiet.quiet > 2)
                            Console.Write("Done!\n");
                    }
                    if (app != "")
                    {
                        if (BeQuiet.quiet > 2)
                            Console.Write("Grabbing dol...");

                        if (app.Substring(app.Length - 4, 4) == ".dol")
                        {
                            Directory.CreateDirectory(Path.Combine(temp, "dol"));
                            File.Copy(app, Path.Combine(temp, "dol", "00000001.app"));
                        }
                        else
                        {
                            twad.LoadFile(app);
                            twad.Unpack(Path.Combine(temp, "dol"));
                        }

                        File.Copy(Path.Combine(temp, "dol", "00000001.app"), Path.Combine(temp, "main", "00000001.app"), true);

                        if (BeQuiet.quiet > 2)
                            Console.Write("Done!\n");
                    }
                    u.ReplaceFile(1, Path.Combine(temp, "main", "00000000", "meta", "banner.bin"));
                    u.ReplaceFile(2, Path.Combine(temp, "main", "00000000", "meta", "icon.bin"));
                    u.ReplaceFile(3, Path.Combine(temp, "main", "00000000", "meta", "sound.bin"));
                    u.Save(Path.Combine(temp, "main", "00000000.app"));
                    DeleteADir.DeleteDirectory(Path.Combine(temp, "main", "00000000"));
                    wad.CreateNew(Path.Combine(temp, "main"));
                    DeleteADir.DeleteDirectory(temp);
                }

                if (BeQuiet.quiet > 2 && fake == true)
                    Console.WriteLine("FakeSigning WAD");
                wad.FakeSign = fake;

                if (id != "" || lwrid != "")
                {
                    if (id != "")
                    {
                        if (BeQuiet.quiet > 2)
                            Console.WriteLine("Changing channel ID to: {0}", id);
                    }
                    else
                    {
                        id = wad.UpperTitleID;
                    }

                    if (lwrid != "")
                    {
                        if (BeQuiet.quiet > 2)
                            Console.WriteLine("Changing channel type to: {0}", lwrid);
                    }
                    else
                    {
                        lwrid = "CHANNEL";
                    }

                    if (lwrid == "CHANNEL")
                        wad.ChangeTitleID(LowerTitleID.Channel, id);
                    else if (lwrid == "DLC")
                        wad.ChangeTitleID(LowerTitleID.DLC, id);
                    else if (lwrid == "GAMECHANNEL")
                        wad.ChangeTitleID(LowerTitleID.GameChannel, id);
                    else if (lwrid == "HIDDENCHANNELS")
                        wad.ChangeTitleID(LowerTitleID.HiddenChannels, id);
                    else if (lwrid == "SYSTEMCHANNELS")
                        wad.ChangeTitleID(LowerTitleID.SystemChannels, id);
                    else if (lwrid == "SYSTEMTITLES")
                        wad.ChangeTitleID(LowerTitleID.SystemTitles, id);
                }
                if (ios > -1)
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Changing startup IOS to: {0}", ios);
                    wad.ChangeStartupIOS(ios);
                }
                if (title != "")
                {
                    if (BeQuiet.quiet > 2)
                        Console.WriteLine("Changing channel title to: {0}", title);
                    wad.ChangeChannelTitles(title);
                }

                if (BeQuiet.quiet > 2)
                    Console.Write("Saving file...");

                if (output.Substring(output.Length - 4, 4).ToUpper() != ".WAD")
                    output += ".wad";

                wad.Save(output);

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (BeQuiet.quiet > 1)
                    Console.WriteLine("Operation completed succesfully!");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Index was outside the bounds of the array.")
                {
                    Console.WriteLine("You need to have all the required .app files, a tmd file, a tik file, and a cert file to do this.");
                    Console.WriteLine("");
                    Console.WriteLine("Error: SHARPII_NET_CORE_NUSD_MISSING_FILES");
                    ExceptionListRan = 1;
                    if (OperatingSystem.Windows())
                    {
                        Environment.Exit(0x00003E9D);
                    }
                    else
                    {
                        Environment.Exit(0x0000001F);
                    }
                }
                if (ExceptionListRan == 0)
                {
                    Console.WriteLine("An unknown error occured, please try again");
                    Console.WriteLine("");
                    Console.WriteLine("ERROR DETAILS: {0}", ex.Message);
                    Console.WriteLine("Error: SHARPII_NET_CORE_WAD_UNKNOWN");
                    if (OperatingSystem.Windows())
                    {
                        Environment.Exit(0x00003E82);
                    }
                    else
                    {
                        Environment.Exit(0x00000004);
                    }
                }
            }
        }

        private static void Unpack(string[] args)
        {
            //setting up variables
            string input = args[2];
            string output = args[3];
            bool cid = false;

            //Check if file exists
            if (File.Exists(input) == false)
            {
                Console.WriteLine("ERROR: Unable to open file: {0}", input);
                Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                Console.WriteLine("Error: SHARPII_NET_CORE_WAD_FILE_ERR");
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

            //-cid argument
            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i].ToUpper())
                {
                    case "-CID":
                        cid = true;
                        break;
                }
            }

            //Run main part, and check for exceptions
            try
            {
                WAD wad = new WAD();

                if (BeQuiet.quiet > 2)
                    Console.Write("Loading file...");

                wad.LoadFile(input);

                if (BeQuiet.quiet > 2)
                    Console.Write("Done!\n");

                if (BeQuiet.quiet > 2)
                    Console.Write("Unpacking WAD...");

                wad.Unpack(output, cid);

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
                Console.WriteLine("Error: SHARPII_NET_CORE_WAD_UNKNOWN");
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

        public static void WAD_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii .Net Core v{0} - Ported and Maintained by TheShadowEevee, originally by person66", ProgramVersion.version);
            Console.WriteLine("Using a modified version of libWiiSharp, originally made by leathl");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       ./Sharpii WAD [-p | -u | -e | -i] input output [arguments]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Arguments:");
            Console.WriteLine("");
            Console.WriteLine("       input          The input file/folder");
            Console.WriteLine("       output         The output file/folder");
            Console.WriteLine("       -p             Pack WAD");
            Console.WriteLine("       -u             Unpack WAD");
            Console.WriteLine("       -e             Edit WAD");
            Console.WriteLine("       -i             Get WAD info");
            Console.WriteLine("");
            Console.WriteLine("    Arguments for unpacking:");
            Console.WriteLine("");
            Console.WriteLine("         -cid           Use Content ID as name");
            Console.WriteLine("");
            Console.WriteLine("    Arguments for info:");
            Console.WriteLine("");
            Console.WriteLine("         -o [output]    Output info to text file");
            Console.WriteLine("         -titles        Display titles in all languages");
            Console.WriteLine("");
            Console.WriteLine("    Arguments for packing/editing:");
            Console.WriteLine("");
            Console.WriteLine("         -id [TitleID]  Change the 4-character title id");
            Console.WriteLine("         -ios [IOS]     Change the Startup IOS");
            Console.WriteLine("         -title [title] Change the Channel name/title.");
            Console.WriteLine("                        If there are spaces, surround in quotes");
            Console.WriteLine("         -f             Fakesign the WAD");
            Console.WriteLine("         -type [type]   Change the Channel type. Possible values are:");
            Console.WriteLine("                        Channel, DLC, GameChannel, HiddenChannels,");
            Console.WriteLine("                        SystemChannels, or SystemTitles");
            Console.WriteLine("         -sound [wad]   Use the sound from 'wad'");
            Console.WriteLine("         -banner [wad]  Use the banner from 'wad'");
            Console.WriteLine("         -icon [wad]    Use the icon from 'wad'");
            Console.WriteLine("         -dol [wad]     Use the dol from 'wad'");
            Console.WriteLine("                        NOTE: you can also just enter the path to a");
            Console.WriteLine("                        regular dol file, instead of a wad");
        }
    }
}