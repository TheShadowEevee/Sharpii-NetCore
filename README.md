# Sharpii .Net Core Port - A command line libWiiSharp tool ported for all OS's

## Repo info

Sharpii is a command line app for windows that person66 made and was ported to .Net by TheShadowEevee, which uses leathl's libWiiSharp to perform tasks such as:

- Pack, unpack, or edit .wad files
- Pack, and unpack U8 archives
- Patch IOS .wad files with various patches
- Download files from NUS
- Convert a .wav file to .bns, and vice versa
- Convert an image file to a .tpl, and vice versa
- Send a .dol or .wad to the Homebrew Channel over Wi-Fi

.Net was renamed from .Net Core awhile back but Sharpii .Net doesn't sound as good and much more would be pointless "rebranding" so the name will stay.

## Download

You can download the latest version of Sharpii on the project's releases page: <https://github.com/TheShadowEevee/Sharpii-NetCore/releases/>
Releases will have certain executables pre-made. If an executable you need isn't there, you can follow the compilation instructions in the wiki. I will compile this myself for certain people if asked via Discord (Usually for projects such as RC24's Linux patcher.)

> [!IMPORTANT]  
> MacOS users may need to run the following command in the directory Sharpii is downloaded to. See [this issue](https://github.com/TheShadowEevee/Sharpii-NetCore/issues/11) for more information.  
> `codesign --sign - --force --preserve-metadata=entitlements,requirements,flags,runtime ./Sharpii`  
> Please ensure you replace `./Sharpii` with the full name of the downloaded binary.  

## Compiling

To compile, do the following:

1. Ensure you have the [.Net SDK](https://github.com/dotnet/core) installed. Sharpii-NetCore is compiled normally with .Net v7.
2. Run `git clone https://github.com/TheShadowEevee/Sharpii-NetCore`
3. Move into the new directory and run `dotnet publish -c {type} -r {RID}` replacing `{type}` with Debug or Release and `{RID}` with a valid RID from [here](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) or [here](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json).
4. Binaries are shipped as .7z files on ultra compression.

## Issues/Pull Requests

All issues with this version of Sharpii should go in this fork's issue tracker. I will look into any issue whether it's caused by the port or a remenant from the original iteration of Sharpii. Pull requests are appreciated if they fix an issue, but it may take a bit to review.

## Giving Credit

No credit is needed to use this program! If you do give credit, make sure to put the original creator(s) names first! (person66 for Sharpii, and leathl for libWiiSharp)
