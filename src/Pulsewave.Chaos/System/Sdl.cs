// Copyright (c) Pulsewave. All rights reserved.
// The source code is licensed under MIT License.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pulsewave.Chaos.System;

/// <summary>
/// Represents the library with general SDL functions.
/// </summary>
public static partial class Sdl
{
    internal const string Library = "SDL3.dll";

    /// <summary>
    /// Clear any previous error message for this thread.
    /// </summary>
    public static void ClearError() => SDL_ClearError();

    /// <summary>
    /// Get the lastest message with information about the specific error that occurred,
    /// or an empty string if there hasn't been an error message set since the last call to <see cref="ClearError"/>.
    /// </summary>
    /// <remarks>It is possible for multiple errors to occur before calling <see cref="GetLatestError"/>. Only the last error is returned.
    /// The message is only applicable when an SDL function has signaled an error.
    /// </remarks>
    /// <returns>The last error message.</returns>
    public static string GetLatestError() => SDL_GetError();

    /// <summary>
    /// Get the version of the SDL that is linked against your program.
    /// </summary>
    /// <returns>The version of the linked library.</returns>
    public static string GetVersion()
    {
        int version = SDL_GetVersion();

        int major = version / 1000000;
        int minor = version / 1000 % 1000;
        int patch = version % 1000;

        return $"{major}.{minor}.{patch}";
    }

    /// <summary>
    /// Initializes the specified SDL subsystem.
    /// </summary>
    /// <param name="subsystem">The subsystem to initialize.</param>
    /// <returns>Returns true on success or false on failure; call <see cref="GetLatestError"/> for more information.</returns>
    public static bool Init(SubSystem subsystem) => SDL_InitSubSystem(subsystem);

    /// <summary>
    /// Clean up all initialized subsystems.
    /// </summary>
    /// <remarks>You should call this function even if you have already shutdown each initialized subsystem with <see cref="QuitSubSystem"/>.
    /// It is safe to call this function even in the case of errors in initialization.
    /// </remarks>
    public static void Quit() => SDL_Quit();

    /// <summary>
    /// Shut down the specified SDL subsystem.
    /// </summary>
    /// <remarks>You still need to call <see cref="Quit"/> even if you close all open subsystems with <see cref="QuitSubSystem"/>.</remarks>
    /// <param name="subsystem">The subsystem to shut down.</param>
    public static void QuitSubSystem(SubSystem subsystem) => SDL_QuitSubSystem(subsystem);

    /// <summary>
    /// Get a mask of the specified subsystems which are currently initialized.
    /// </summary>
    /// <param name="subSystem">The subsystem to check if is initialized.</param>
    /// <returns>a mask of all initialized subsystems if using <see cref="SubSystem.None"/>, otherwise it returns the initialization status of the specified subsystems.</returns>
    public static SubSystem WasInit(SubSystem subSystem) => SDL_WasInit(subSystem);

    /// <summary>
    /// Flags for initializing the SDL subsystems.
    /// </summary>
    [Flags]
    public enum SubSystem : uint
    {
        /// <summary>
        /// Represents an empty state. Mostly used for WasInit where return all initialized subsystems.
        /// </summary>
        None = 0x00000000u,

        /// <summary>
        /// Initialize the audio subsystem. Implicitly initializes the events subsystem.
        /// </summary>
        Audio = 0x00000010u,

        /// <summary>
        /// Initialize the video subsystem. Implicitly initializes the events subsystem.
        /// </summary>
        Video = 0x00000020u,

        /// <summary>
        /// Initialize the joystick subsystem. Implicitly initializes the events subsystem.
        /// </summary>
        Joystick = 0x00000200u,

        /// <summary>
        /// Initialize the haptic (force feedback) subsystem.
        /// </summary>
        Haptic = 0x00001000u,

        /// <summary>
        /// Initialize the gamepad subsystem. Implicitly initializes the joystick subsystem.
        /// </summary>
        Gamepad = 0x00002000u,

        /// <summary>
        /// Initialize the events subsystem.
        /// </summary>
        Events = 0x00004000u,
    }

    [LibraryImport(Library)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_ClearError();

    [LibraryImport(Library)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.LPStr)]
    private static partial string SDL_GetError();

    [LibraryImport(Library)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int SDL_GetVersion();

    [LibraryImport(Library)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool SDL_InitSubSystem(SubSystem subSystem);

    [LibraryImport(Library)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_QuitSubSystem(SubSystem subSystem);

    [LibraryImport(Library)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_Quit();

    [LibraryImport(Library)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial SubSystem SDL_WasInit(SubSystem subSystem);
}
