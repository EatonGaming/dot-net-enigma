using DotNetEnigma.Enigma.KeyProcessing;
using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using DotNetEnigma.Utilities;
using System;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Keyboard
{
    public class Keyboard : IKeyboard, IKeyProvider
    {
        public Keyboard() {}

        public static Keyboard Default() => new Keyboard();

        public event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;

        public void OnKeyPressed(Key keyPressed)
        {
            Guard.IsNotEqualTo(keyPressed, Key.Unknown, nameof(keyPressed));

            var handler = KeyProvidedEvent;

            handler?.Invoke(this, new KeyPressedEventArgs() { KeyPressed = keyPressed });
        }
    }
}
