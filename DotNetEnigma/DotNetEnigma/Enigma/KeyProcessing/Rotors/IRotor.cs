using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    interface IRotor
    {
        List<(char left, char right)> WiringConfiguration { get; }
        RotorNumber RotorNumber { get; }
        int NotchPosition { get; }

        void Step();
        char ProcessCharacter(char character, bool reverse);
    }
}
