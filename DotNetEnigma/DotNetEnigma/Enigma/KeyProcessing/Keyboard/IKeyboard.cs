using System;

namespace DotNetEnigma.Enigma.KeyProcessing.Keyboard
{
    public interface IKeyboard
    {
        void OnKeyPressed(Key key);
        void OnKeyPressed(char key);
        Key PressKey(Key key);
        Key PressKey(char key);

        event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;
    }
}
