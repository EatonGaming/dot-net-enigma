using System;

namespace DotNetEnigma.Enigma.Keyboard
{
    public class KeyPressedEventArgs : EventArgs
    {
        public Key KeyPressed { get; set; }
    }
}
