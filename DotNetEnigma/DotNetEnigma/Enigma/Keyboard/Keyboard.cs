using System;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Keyboard
{
    public class Keyboard : IKeyboard
    {
        public IEnumerable<Key> Keys { get; private set; }

        public event EventHandler KeyPressedEvent;

        public Keyboard()
        {
            InitializeListOfKeys();
        }

        public static IKeyboard Default() => new Keyboard();

        public void OnKeyPressed(Key keyPressed)
        {
            if (keyPressed == Key.Unknown)
                throw new ArgumentNullException(nameof(keyPressed));

            var handler = KeyPressedEvent;

            handler?.Invoke(this, new KeyPressedEventArgs() { KeyPressed = keyPressed });
        }

        private void InitializeListOfKeys()
        {
            Keys = (Key[])Enum.GetValues(typeof(Key));
        }
    }
}
