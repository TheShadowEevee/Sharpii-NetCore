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
    partial class ERROR_Stuff
    {
        public static int ErrCodeFound = 0;
        public static void ERROR(string[] args)
        {
            try
            {
                if (args[1] == "SHARPII_NET_CORE_BNS_FILE_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_FILE_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }

                if (args[1] == "SHARPII_NET_CORE_IOS_FILE_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }

                if (args[1] == "SHARPII_NET_CORE_NUSD_FILE_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }

                if (args[1] == "SHARPII_NET_CORE_TPL_FILE_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }

                if (args[1] == "SHARPII_NET_CORE_U8_FILE_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_FILE_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the file doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the file's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_BNS_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_IOS_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_MAIN_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_TPL_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_U8_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_UNKNOWN")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An untracked error has occured.");
                    Console.WriteLine("Use the error text to self-diagnose.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_NO_IP")
                {
                    Console.WriteLine("");
                    Console.WriteLine("No IP address was listed for the Wii.");
                    Console.WriteLine("Furthermore, no IP address is saved from previous uses.");
                    Console.WriteLine("If this doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_NO_DOL")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -DOL flag, but no DOL file was provided.");
                    Console.WriteLine("Provide the proper DOL file.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_MISSING_DLL_WADINSTALLER")
                {
                    Console.WriteLine("");
                    Console.WriteLine("The WadInstaller.dll couldn't be found.");
                    Console.WriteLine("This error SHOULD NOT APPEAR in this Sharpii port.");
                    Console.WriteLine("Open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_NO_IOS")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -IOS flag, but no IOS was provided.");
                    Console.WriteLine("Provide a proper IOS.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_INVALID_IOS")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -IOS flag, but an invalid IOS was provided.");
                    Console.WriteLine("Provide a proper IOS.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_HBC_NO_WAD")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -WAD flag, but no WAD was provided.");
                    Console.WriteLine("Provide a proper WAD.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_IOS_NO_SLOT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -SLOT flag, but no slot was provided.");
                    Console.WriteLine("Provide a proper slot.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_IOS_INVALID_SLOT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -SLOT flag, but an invalid slot was provided.");
                    Console.WriteLine("Provide a proper slot.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_IOS_NO_VERSION")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -V flag, but no version was provided.");
                    Console.WriteLine("Provide a proper version.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_IOS_INVALID_VERSION")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -V flag, but no version was provided.");
                    Console.WriteLine("Provide a proper version.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_IOS_NO_OUTPUT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -O flag, but no output was provided.");
                    Console.WriteLine("Provide a proper output.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_NO_VERSION")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -V flag, but no version was provided.");
                    Console.WriteLine("Provide a proper version.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_INVALID_VERSION")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -V flag, but an invalid version was provided.");
                    Console.WriteLine("Provide a proper version.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_NO_OUTPUT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -O flag, but no output was provided.");
                    Console.WriteLine("Provide a proper output.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_NO_ID")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -ID flag, but no id was provided.");
                    Console.WriteLine("Provide a proper id.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_NO_IOS")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -IOS flag, but no ios was provided.");
                    Console.WriteLine("Provide a proper ios.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_MAIN_MISSING_DLL_LIBWIISHARP")
                {
                    Console.WriteLine("");
                    Console.WriteLine("The libWiiSharp.dll couldn't be found.");
                    Console.WriteLine("This error SHOULD NOT APPEAR in this Sharpii port.");
                    Console.WriteLine("Open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_MAIN_INVALID_ARG")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An invalid argument was provided.");
                    Console.WriteLine("Check the options you are using to start Sharpii.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_TPL_INVALID_ARG")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An invalid argument was provided.");
                    Console.WriteLine("Check the options you are using to start Sharpii.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_U8_INVALID_ARG")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An invalid argument was provided.");
                    Console.WriteLine("Check the options you are using to start Sharpii.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_INVALID_ARG")
                {
                    Console.WriteLine("");
                    Console.WriteLine("An invalid argument was provided.");
                    Console.WriteLine("Check the options you are using to start Sharpii.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_TPL_NO_FORMAT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -FORMAT flag, but no format was provided.");
                    Console.WriteLine("Provide a proper format.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_UNKNOWN_FORMAT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -FORMAT flag, but an invalid format was provided.");
                    Console.WriteLine("Provide a proper format.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_U8_NON_U8")
                {
                    Console.WriteLine("");
                    Console.WriteLine("The provided file is not a U8 archive.");
                    Console.WriteLine("Provide a U8 archive.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_U8_FOLDER_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the folder doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the folders's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_FOLDER_ERR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Either the folder doesn't exist, or Sharpii doesn't have permission to open it.");
                    Console.WriteLine("Check the folders's permissions and that it's in the right place.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_U8_NO_TITLE")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -IMET flag, but no title was provided.");
                    Console.WriteLine("Provide a proper title.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_U8_TWO_HEADERS")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -IMET and -IMD5 flags, but you can't use two headers.");
                    Console.WriteLine("Provide only one flag.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_NO_OUTPUT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -OUTPUT flag, but no output was provided.");
                    Console.WriteLine("Provide a proper output.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_NO_ID")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -ID flag, but no id was provided.");
                    Console.WriteLine("Provide a proper id.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_SHORT_ID")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -ID flag, but the provided id was too short to be correct.");
                    Console.WriteLine("Provide a proper id.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_NO_TYPE")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -TYPE or -IOS flag, but no type was provided.");
                    Console.WriteLine("Provide a proper type.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_UNKNOWN_TYPE")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -TYPE flag, but an unknown type was provided.");
                    Console.WriteLine("Provide a proper type.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_INVALID_SLOT")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -IOS flag, but an invalid slot was provided.");
                    Console.WriteLine("Provide a proper slot.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_NO_TITLE")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -TITLE flag, but no title was provided.");
                    Console.WriteLine("Provide a proper title.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_NO_SOUND")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -SOUND flag, but no wad file to provide sound was provided.");
                    Console.WriteLine("Provide a proper wad.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_NO_BANNER")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the BANNER flag, but no wad file to provide a banner was provided.");
                    Console.WriteLine("Provide a proper wad.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_WAD_NO_DOL")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -DOL flag, but no wad or dol file was provided.");
                    Console.WriteLine("Provide a proper wad or dol file.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_BAD_ID")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You used the -ID flag, but an invalid id was provided.");
                    Console.WriteLine("Provide a proper id.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_MISSING_FILES")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You need to have all the required .app files, a tmd file, a tik file, and a cert file to pack a wad.");
                    Console.WriteLine("Ensure all files are present.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_REMOTE_404")
                {
                    Console.WriteLine("");
                    Console.WriteLine("The remote server returned a 404 error. Check your Title ID.");
                    Console.WriteLine("If you have a CETK file, please place it in the same directory as Sharpii saves the NUS Files to.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (args[1] == "SHARPII_NET_CORE_NUSD_WEBREQUEST_FAIL")
                {
                    Console.WriteLine("");
                    Console.WriteLine("A WebRequest Error occurred. This usually means that Sharpii can not properly download and save the file.");
                    Console.WriteLine("Please ensure you have the proper permissions to use the current folder or files.");
                    Console.WriteLine("If that doesn't help, open an issue on GitHub!");
                    Console.WriteLine("https://github.com/TheShadowEevee/Sharpii-NetCore/issues");
                    Console.WriteLine("");
                    ErrCodeFound = 1;
                }
                if (ErrCodeFound != 1)
                {
                    Error_help();
                }
            }
            catch (Exception)
            {
                Error_help();
            }
        }
        public static void Error_help()
        {
            Console.WriteLine("");
            Console.WriteLine("Sharpii {0} - Errors - A tool by person66, using libWiiSharp.dll by leathl", ProgramVersion.version);
            Console.WriteLine("Sharpii .Net Core Port by TheShadowEevee");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Usage:");
            Console.WriteLine("");
            Console.WriteLine("       ./Sharpii ERRORS [Error Text]");
            Console.WriteLine("");
            Console.WriteLine("       Ex. \"Sharpii ERRORS SHARPII_NET_CORE_BNS_FILE_ERR\"");
            Console.WriteLine("");
            Console.WriteLine("  Error Format:");
            Console.WriteLine("       SHARPII_NET_CORE_[Subsection]_[Description]_[ID NO]");
            Console.WriteLine("");
        }
    }
}
