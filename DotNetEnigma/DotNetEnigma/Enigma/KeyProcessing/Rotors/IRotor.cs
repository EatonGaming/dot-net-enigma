﻿using System.Collections.Generic;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public interface IRotor
    {
        List<(char left, char right)> WiringConfiguration { get; }
        RotorNumber RotorNumber { get; set; }
        int NotchPosition { get; set; }

        void Step();
        char ProcessCharacter(char character, bool reverse);
    }
}
