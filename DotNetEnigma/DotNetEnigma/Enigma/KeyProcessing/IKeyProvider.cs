using System;

namespace DotNetEnigma.Enigma.KeyProcessing
{
    public interface IKeyProvider
    {
        event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;
    }
}
