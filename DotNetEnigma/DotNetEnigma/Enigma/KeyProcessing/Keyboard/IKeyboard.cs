using System;

namespace DotNetEnigma.Enigma.KeyProcessing.Keyboard
{
    public interface IKeyboard
    {
        void OnKeyPressed(Key key);
        void OnKeyPressed(char key);

        event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;
    }
}
