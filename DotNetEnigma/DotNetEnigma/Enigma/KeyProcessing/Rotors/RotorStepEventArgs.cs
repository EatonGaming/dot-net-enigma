using System;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public class RotorStepEventArgs : EventArgs
    {
        public RotorNumber RotorNumber { get; set; }

        public RotorStepEventArgs(RotorNumber number)
        {
            RotorNumber = number;
        }
    }
}
