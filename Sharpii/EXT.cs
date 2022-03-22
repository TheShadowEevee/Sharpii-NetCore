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

using System;

namespace Sharpii
{
    partial class ERRORCODE_Stuff
    {
        public static int ErrCodeFound = 0;
        public static void ERRORCODE(string[] args)
        {
            try
            {
                if (args[1] == "0")
                {
                    Console.WriteLine("");
                    Console.WriteLine("No errors reported/Likely successful exit");
                    Console.WriteLine("");
                }
                if (args[1] == "16001")
                {
                    Console.WriteLine("");
                    Console.WriteLine("File Access Issue/Missing File. (SHARPII_NET_CORE_xxx_FILE_ERR)");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }

                if (args[1] == "16002")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Unknown Error/Untracked Error. (SHARPII_NET_CORE_xxx_UNKNOWN)");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }

                if (args[1] == "16003")
                {
                    Console.WriteLine("");
                    Console.WriteLine("No IP was provided for remote Wii access. (SHARPII_NET_CORE_HBC_NO_IP)");
                    Console.WriteLine("No IP address was listed for the Wii.");
                    Console.WriteLine("Furthermore, no IP address is saved from previous uses.");
                    Console.WriteLine("If this doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16004")
                {
                    Console.WriteLine("DOL Flag was used, but no file provided. (SHARPII_NET_CORE_xxx_NO_DOL)");
                    Console.WriteLine("You used the -DOL flag, but no DOL file was provided.");
                    Console.WriteLine("Provide the proper DOL file.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16005")
                {
                    Console.WriteLine("");
                    Console.WriteLine("A Critical DLL (WadInstaller.dll) couldn't be found. (SHARPII_NET_CORE_HBC_MISSING_DLL_WADINSTALLER)");
                    Console.WriteLine("The WadInstaller.dll couldn't be found.");
                    Console.WriteLine("This error SHOULD NOT APPEAR in this Sharpii port.");
                    Console.WriteLine("Open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16006")
                {
                    Console.WriteLine("");
                    Console.WriteLine("IOS Flag was used, but no IOS provided. (SHARPII_NET_CORE_xxx_NO_IOS)");
                    Console.WriteLine("You used the -IOS flag, but no IOS was provided.");
                    Console.WriteLine("Provide a proper IOS.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16007")
                {
                    Console.WriteLine("");
                    Console.WriteLine("IOS Flag was used, but an invalid IOS provided. (SHARPII_NET_CORE_xxx_INVALID_IOS)");
                    Console.WriteLine("You used the -IOS flag, but an invalid IOS was provided.");
                    Console.WriteLine("Provide a proper IOS.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16008")
                {
                    Console.WriteLine("");
                    Console.WriteLine("WAD Flag was used, but no wad provided. (SHARPII_NET_CORE_HBC_NO_WAD)");
                    Console.WriteLine("You used the -WAD flag, but no WAD was provided.");
                    Console.WriteLine("Provide a proper WAD.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16009")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Slot Flag was used, but no slot provided. (SHARPII_NET_CORE_IOS_NO_SLOT)");
                    Console.WriteLine("You used the -SLOT flag, but no slot was provided.");
                    Console.WriteLine("Provide a proper slot.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16010")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Slot Flag was used, but an invalid slot provided. (SHARPII_NET_CORE_xxx_INVALID_SLOT)");
                    Console.WriteLine("You used the -SLOT flag, but an invalid slot was provided.");
                    Console.WriteLine("Provide a proper slot.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16011")
                {
                    Console.WriteLine("");
                    Console.WriteLine("V Flag was used, but no version provided. (SHARPII_NET_CORE_xxx_NO_VERSION)");
                    Console.WriteLine("You used the -V flag, but no version was provided.");
                    Console.WriteLine("Provide a proper version.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16012")
                {
                    Console.WriteLine("");
                    Console.WriteLine("V Flag was used, but an invalid version provided. (SHARPII_NET_CORE_xxx_INVALID_VERSION)");
                    Console.WriteLine("You used the -V flag, but no version was provided.");
                    Console.WriteLine("Provide a proper version.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16013")
                {
                    Console.WriteLine("");
                    Console.WriteLine("O Flag was used, but no output provided. (SHARPII_NET_CORE_xxx_NO_OUTPUT)");
                    Console.WriteLine("You used the -O flag, but no output was provided.");
                    Console.WriteLine("Provide a proper output.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16014")
                {
                    Console.WriteLine("");
                    Console.WriteLine("ID Flag was used, but no id provided. (SHARPII_NET_CORE_xxx_NO_ID)");
                    Console.WriteLine("You used the -ID flag, but no id was provided.");
                    Console.WriteLine("Provide a proper id.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16015")
                {
                    Console.WriteLine("");
                    Console.WriteLine("A Critical DLL (libWiiSharp.dll) couldn't be found. (SHARPII_NET_CORE_MAIN_MISSING_DLL_LIBWIISHARP)");
                    Console.WriteLine("The libWiiSharp.dll couldn't be found.");
                    Console.WriteLine("This error SHOULD NOT APPEAR in this Sharpii port.");
                    Console.WriteLine("Open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16016")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An invalid argument was passed when starting Sharpii. (SHARPII_NET_CORE_xxx_INVALID_ARG)");
                    Console.WriteLine("An invalid argument was provided.");
                    Console.WriteLine("Check the options you are using to start Sharpii.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16017")
                {
                    Console.WriteLine("");
                    Console.WriteLine("FORMAT Flag was used, but no format provided. (SHARPII_NET_CORE_TPL_NO_FORMAT)");
                    Console.WriteLine("You used the -FORMAT flag, but no format was provided.");
                    Console.WriteLine("Provide a proper format.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16018")
                {
                    Console.WriteLine("");
                    Console.WriteLine("FORMAT Flag was used, but invalid format provided. (SHARPII_NET_CORE_TPL_INVALID_FORMAT)");
                    Console.WriteLine("You used the -FORMAT flag, but an invalid format was provided.");
                    Console.WriteLine("Provide a proper format.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16019")
                {
                    Console.WriteLine("");
                    Console.WriteLine("A non U8 archive file was provided. (SHARPII_NET_CORE_U8_NON_U8)");
                    Console.WriteLine("The provided file is not a U8 archive.");
                    Console.WriteLine("Provide a U8 archive.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16020")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Folder Access Issue/Missing Folder. (SHARPII_NET_CORE_xxx_FOLDER_ERR)");
                    Console.WriteLine("Either the folder doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the folders's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16021")
                {
                    Console.WriteLine("");
                    Console.WriteLine("IMET Flag was used, but no title provided. (SHARPII_NET_CORE_xxx_NO_TITLE");
                    Console.WriteLine("You used the -IMET flag, but no title was provided.");
                    Console.WriteLine("Provide a proper title.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16022")
                {
                    Console.WriteLine("");
                    Console.WriteLine("IMET and IMD5 Flags were used, but only one can be used. (SHARPII_NET_CORE_U8_TWO_HEADERS");
                    Console.WriteLine("You used the -IMET and -IMD5 flags, but you can't use two headers.");
                    Console.WriteLine("Provide only one flag.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16023")
                {
                    Console.WriteLine("");
                    Console.WriteLine("ID Flag was used, but short ID provided. (SHARPII_NET_CORE_WAD_SHORT_ID)");
                    Console.WriteLine("You used the -ID flag, but the provided id was too short to be correct.");
                    Console.WriteLine("Provide a proper id.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16024")
                {
                    Console.WriteLine("");
                    Console.WriteLine("TYPE or IOS Flag used, but no type provided. (SHARPII_NET_CORE_WAD_NO_TYPE)");
                    Console.WriteLine("You used the -TYPE or -IOS flag, but no type was provided.");
                    Console.WriteLine("Provide a proper type.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16025")
                {
                    Console.WriteLine("");
                    Console.WriteLine("TYPE or IOS Flag used, but provided type unknown. (SHARPII_NET_CORE_WAD_UNKNOWN_TYPE)");
                    Console.WriteLine("You used the -TYPE flag, but an unknown type was provided.");
                    Console.WriteLine("Provide a proper type.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16026")
                {
                    Console.WriteLine("");
                    Console.WriteLine("SOUND Flag used, but no wad provided. (SHARPII_NET_CORE_WAD_NO_SOUND)");
                    Console.WriteLine("You used the -SOUND flag, but no wad file to provide sound was provided.");
                    Console.WriteLine("Provide a proper wad.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16027")
                {
                    Console.WriteLine("");
                    Console.WriteLine("BANNER Flag used, but no wad provided. (SHARPII_NET_CORE_WAD_NO_BANNER)");
                    Console.WriteLine("You used the BANNER flag, but no wad file to provide a banner was provided.");
                    Console.WriteLine("Provide a proper wad.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16028")
                {
                    Console.WriteLine("");
                    Console.WriteLine("ID Flag was used, but invalid id provided. (SHARPII_NET_CORE_xxx_BAD_ID)");
                    Console.WriteLine("You used the -ID flag, but an invalid id was provided.");
                    Console.WriteLine("Provide a proper id.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "16029")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Not all files needed to pack a wad are present. (SHARPII_NET_CORE_NUSD_MISSING_FILES)");
                    Console.WriteLine("You need to have all the required .app files, a tmd file, a tik file, and a cert file to pack a wad.");
                    Console.WriteLine("Ensure all files are present");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (ErrCodeFound != 1)
                {
                    ExitCode_help();
                }
            }
            catch (Exception)
            {
                ExitCode_help();
            }
        }
        public static void ExitCode_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii .Net Core v{0} - Ported and Maintained by TheShadowEevee, originally by person66", ProgramVersion.version);
            Console.WriteLine("Using a modified version of libWiiSharp, originally made by leathl");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       ./Sharpii EXITCODES [Exit]");
            Console.WriteLine("");
            Console.WriteLine("       Ex. \"Sharpii EXITCODES 16001\"");
            Console.WriteLine("");
        }
    }
}
