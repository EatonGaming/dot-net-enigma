using System;

namespace DotNetEnigma.Enigma.KeyProcessing.Keyboard
{
    public interface IKeyboard
    {
        void OnKeyPressed(Key key);

        event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;
    }
}
