# 35.HH

## Overview
A legacy .NET Framework workspace containing audio-focused desktop utilities and shared helper libraries.
The solution includes downloader, copier, renamer, and master applications, plus common core/data libraries.

## Dependencies
- .NET Framework 4.5
- WinForms
- `Newtonsoft.Json`
- `PixelSoftOffice.Core`
- `PixelSoftOffice.Data`
- `PixelSoftOffice.Web.Extensions`
- `taglib-sharp`
- `YoutubeExtractor`

## Setup
1. Open `35.HH.sln` in Visual Studio.
2. Restore the NuGet packages used by the legacy projects.
3. Ensure the bundled DLLs in the repository root are present.
4. Build the solution before running any of the desktop apps.

## Run
- Launch the relevant project from Visual Studio.
- Main applications include `Master`, `Copier`, `ReNamer`, and `Downloader`.

## Notes
Because this is a legacy solution, several dependencies are referenced as local binaries rather than modern NuGet packages.