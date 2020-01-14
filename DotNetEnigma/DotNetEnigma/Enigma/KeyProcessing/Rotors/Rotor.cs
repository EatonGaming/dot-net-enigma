namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public class Rotor
    {
        public char[] AvailableCharacters => GenerateAlphabetCharArray();

        public Rotor() { }

        public static Rotor Default() => new Rotor();

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
    }
}
