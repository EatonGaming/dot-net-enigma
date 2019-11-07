using System.Collections.Generic;

namespace DotNetEnigma.Enigma.KeyProcessing.Keyboard
{
    public interface IKeyboard
    {
        IEnumerable<Key> Keys { get; }

        void OnKeyPressed(Key key);
    }
}
