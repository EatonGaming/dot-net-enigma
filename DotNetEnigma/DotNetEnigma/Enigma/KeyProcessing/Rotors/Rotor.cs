using System.Collections.Generic;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public class Rotor
    {
        public char[] AvailableCharacters => GenerateAlphabetCharArray();

        public List<(char left, char right)> WiringConfiguration { get; private set; }
        public RotorNumber RotorNumber { get; private set; }
        public int NotchPosition { get; private set; }

        public Rotor() { }

        public Rotor(int notchPosition, RotorNumber rotorNumber, string wiringConfiguration)
        {
            NotchPosition = notchPosition;
            RotorNumber = rotorNumber;
            WiringConfiguration = ParseWiringConfiguration(wiringConfiguration);
        }

        public static Rotor Default() => new Rotor();

        public void Step()
        {
            var nextPosition = NotchPosition + 1;

            if (nextPosition > AvailableCharacters.Length - 1) //-1 offset to account for array indexing.
                nextPosition = 0;

            NotchPosition = nextPosition;
        }

        private static char[] GenerateAlphabetCharArray()
        {
            var startIndex = 65;
            var endIndex = 90;
            var alphabet = new char[endIndex - startIndex + 1]; //+1 offset to account for array indexing.

            for (int i = startIndex; i <= endIndex; i++)
            {
                var currentCharacter = (char)i;
                alphabet[i - startIndex] = currentCharacter;
            }

            return alphabet;
        }

        private List<(char left, char right)> ParseWiringConfiguration(string wiringConfiguration)
        {
            var parsedOutput = new List<(char left, char right)>();

            for (int i = 0; i < AvailableCharacters.Length; i++)
            {
                var leftSideOfRotor = AvailableCharacters[i];
                var rightSideOfRotor = wiringConfiguration[i];

                parsedOutput.Add((leftSideOfRotor, rightSideOfRotor));
            }

            return parsedOutput;
        }
    }
}
