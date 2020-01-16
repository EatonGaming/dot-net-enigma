using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public class RotorSequence : IRotorSequence
    {
        public Queue<IRotor> RotorSeries { get; set; }

        public IReflector Reflector { get; set; }

        public RotorSequence() {}

        public event EventHandler<RotorStepEventArgs> RotorRequiresSteppingEvent;

        public char ProcessCharacter(char character)
        {
            var forwardCharacter = SendCharacterThroughRotors(character, reverse: false);

            return SendCharacterThroughRotors(forwardCharacter, reverse: true);
        }

        private char SendCharacterThroughRotors(char character, bool reverse)
        {
            var rotorSeriesToProcess = (reverse) ? RotorSeries.Reverse() : RotorSeries;
            var previousRotorNotchPosition = 0;
            var currentCharacter = character;

            foreach (var rotor in rotorSeriesToProcess)
            {
                var characterWithOffset = (char)(currentCharacter + previousRotorNotchPosition);
                var processedCharacter = rotor.ProcessCharacter(characterWithOffset, reverse);

                currentCharacter = processedCharacter;
                previousRotorNotchPosition = rotor.NotchPosition;
            }

            return currentCharacter;
        }
    }
}
