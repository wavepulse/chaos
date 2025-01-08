// Copyright (c) Pulsewave. All rights reserved.
// The source code is licensed under MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Pulsewave.Chaos.System;

/// <summary>
/// Represents an exception that is thrown when an SDL error occurs.
/// It uses <see cref="Sdl.GetLatestError"/> to get the error message.
/// </summary>
public class SdlException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SdlException"/> class.
    /// </summary>
    public SdlException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SdlException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message from SDL.</param>
    public SdlException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SdlException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message from SDL.</param>
    /// <param name="innerException">The inner exception.</param>
    public SdlException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    [DoesNotReturn]
    internal static void ThrowIfError()
    {
        string message = Sdl.GetLatestError();
        Sdl.ClearError();

        throw new SdlException(message);
    }
}
