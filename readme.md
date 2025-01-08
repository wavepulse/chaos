# Chaos

Chaos is a NuGet package wrapping SDL3 for .NET 8.0 and above. It is designed to be simple and easy to use, while still providing a powerful and flexible API. It will provide classes for creating windows, rendering graphics, handling input, and playing audio, etc... without using the low-level SDL3 API.

## SDL Version

Here is the list of SDL versions that are supported by the Chaos:

| Chaos Version | SDL Version |
|:-------------:|:-----------:|
| `>= 0.1.0`    | `3.1.6`     |

## Development

### Prerequisites

- [.NET 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)

> Is required to build Setup and Tests projects.

### SDL

The SDL3.dll file is not included in the repository. Run the following command to get the SDL3.dll file:

```pswh
.setup.ps1 sdl
```

This will download the SDL3.dll file and place it in the `libs` directory.

## Mentions

Thanks to the following projects for inspiration:

- [SDL2-CS](https://github.com/flibitijibibo/SDL2-CS)
- [Sayers.SDL2.Core](https://github.com/JeremySayers/Sayers.SDL2.Core)
