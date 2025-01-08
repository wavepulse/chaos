// Copyright (c) Pulsewave. All rights reserved.
// The source code is licensed under MIT License.

using Cake.Common.Diagnostics;
using Cake.Common.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Curl;
using Cake.Frosting;
using System.IO.Compression;

namespace Pulsewave.Chaos.Setup;

/// <summary>
/// Setup tasks to get SDL for Pulsewave.Chaos and testing.
/// </summary>
[TaskName("sdl")]
public sealed class SdlTask : FrostingTask
{
    private const string DllName = "SDL3.dll";
    private const string SdlVersion = "3.1.6";
    private const string Sdl = $"SDL3-{SdlVersion}-win32-x64.zip";

    private readonly Uri _sdlDownloadUri = new($"https://github.com/libsdl-org/SDL/releases/download/preview-{SdlVersion}/{Sdl}");
    private readonly DirectoryPath _libs = new("libs");

    /// <summary>
    /// Runs the SDL setup task.
    /// </summary>
    /// <param name="context">The working directory context.</param>
    public override void Run(ICakeContext context)
    {
        context.Information($"Preparing the {_libs} folder...");
        context.CreateDirectory(_libs);

        context.Information($"Downloading SDL {SdlVersion}...");
        context.CurlDownloadFile(_sdlDownloadUri, new CurlDownloadSettings
        {
            FollowRedirects = true,
            ProgressBar = true
        });

        context.Information($"Extracting SDL {SdlVersion} to {_libs}...");

        using (ZipArchive zip = ZipFile.OpenRead(Sdl))
        {
            ZipArchiveEntry? entry = zip.GetEntry(DllName);

            string path = _libs.CombineWithFilePath(DllName).FullPath;
            entry?.ExtractToFile(path, overwrite: true);
        }

        context.Information("Cleaning up...");
        context.DeleteFile(Sdl);

        context.Information("Pulsewave.Chaos has been set up.");
    }
}
