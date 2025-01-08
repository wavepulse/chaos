// Copyright (c) Pulsewave. All rights reserved.
// The source code is licensed under MIT License.

using Pulsewave.Chaos.System;

Console.WriteLine("Using SDL {0}", Sdl.GetVersion());

Sdl.Init(Sdl.SubSystem.Video);

Sdl.QuitSubSystem(Sdl.SubSystem.Video);
Sdl.Quit();
