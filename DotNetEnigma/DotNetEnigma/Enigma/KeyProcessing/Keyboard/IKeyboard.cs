using System.Collections.Generic;

namespace DotNetEnigma.Enigma.KeyProcessing.Keyboard
{
    public interface IKeyboard
    {
        void OnKeyPressed(Key key);
    }
}
