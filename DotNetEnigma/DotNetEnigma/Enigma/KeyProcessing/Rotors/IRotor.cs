using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public interface IRotor
    {
        List<(char left, char right)> WiringConfiguration { get; set; }
        RotorNumber RotorNumber { get; set; }
        int NotchPosition { get; set; }

        void Step();
        char ProcessCharacter(char character, bool reverse);
    }
}
