using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    interface IRotorSequenceBuilder
    {
        void Reset();
        void BuildReflector();
        void BuildRotor(RotorNumber number, int notchPosition);

    }
}
