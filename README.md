# 35.HH

## Summary
A legacy .NET Framework toolbox for audio downloading, copying, renaming, and shared UI/library helpers.

## Dependencies
- .NET Framework 4.5
- WinForms
- `Newtonsoft.Json`
- `PixelSoftOffice.Core`, `PixelSoftOffice.Web.Extensions`, and `PixelSoftOffice.Data`
- Bundled libraries such as `taglib-sharp` and `YoutubeExtractor`

## Setup
1. Open `35.HH.sln` in Visual Studio.
2. Restore NuGet packages and make sure the bundled DLLs are present in the repo root.
3. Build the solution.
4. Run the project you need: `Master`, `Copier`, `ReNamer`, or `Downloader`.