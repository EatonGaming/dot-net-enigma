using System;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Keyboard
{
    public interface IKeyboard
    {
        IEnumerable<Key> Keys { get; }

        void OnKeyPressed(Key key);

        event EventHandler KeyPressedEvent;
    }
}
