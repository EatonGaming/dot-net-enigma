using System;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Keyboard
{
    public interface IKeyboard
    {
        IEnumerable<Key> Keys { get; }

        void PressKey(Key key);

        event EventHandler KeyPressed;
    }
}
