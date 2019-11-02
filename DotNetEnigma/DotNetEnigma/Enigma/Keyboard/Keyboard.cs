using System;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Keyboard
{
    public class Keyboard : IKeyboard
    {
        public IEnumerable<Key> Keys { get; private set; }

        public event EventHandler KeyPressed;

        public Keyboard()
        {
            InitializeListOfKeys();
        }

        public static IKeyboard Default() => new Keyboard();

        public void PressKey(Key key)
        {
            throw new NotImplementedException();
        }

        private void InitializeListOfKeys()
        {
            Keys = (Key[])Enum.GetValues(typeof(Key));
        }
    }
}
