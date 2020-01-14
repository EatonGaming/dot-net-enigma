using System.Collections.Generic;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public interface IRotorSequence
    {
        Queue<IRotor> RotorSeries { get; set; }
        IReflector Reflector { get; set; }

        char ProcessCharacter(char character);
    }
}
