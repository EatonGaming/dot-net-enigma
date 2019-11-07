using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using System;

namespace DotNetEnigma.Enigma.KeyProcessing
{
    public class KeyPressedEventArgs : EventArgs
    {
        public Key KeyPressed { get; set; }
    }
}
