using DotNetEnigma.Enigma.KeyProcessing;
using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using DotNetEnigma.Utilities;
using System;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Keyboard
{
    public class Keyboard : IKeyboard, IKeyProvider
    {
        public IEnumerable<Key> Keys { get; private set; }

        public Keyboard()
        {
            InitializeListOfKeys();
        }

        public event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;

        public static Keyboard Default() => new Keyboard();

        public void OnKeyPressed(Key keyPressed)
        {
            Guard.IsNotEqualTo(keyPressed, Key.Unknown, nameof(keyPressed));

            var handler = KeyProvidedEvent;

            handler?.Invoke(this, new KeyPressedEventArgs() { KeyPressed = keyPressed });
        }

        private void InitializeListOfKeys()
        {
            Keys = (Key[])Enum.GetValues(typeof(Key));
        }
    }
}
