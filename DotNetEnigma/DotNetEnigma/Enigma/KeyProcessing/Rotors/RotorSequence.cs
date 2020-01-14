using System.Collections.Generic;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public class RotorSequence : IRotorSequence
    {
        public Queue<IRotor> RotorSeries { get; set; }

        public IReflector Reflector { get; set; }

        public RotorSequence() { }

        public char ProcessCharacter(char character)
        {
            throw new System.NotImplementedException();
        }
    }
}
