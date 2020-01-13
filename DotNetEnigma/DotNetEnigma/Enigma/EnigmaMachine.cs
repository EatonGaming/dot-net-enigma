using DotNetEnigma.Enigma.KeyProcessing.Keyboard;

namespace DotNetEnigma.Enigma
{
    public class EnigmaMachine : IEnigmaMachine
    {
        private IKeyboard _keyboard = new Keyboard.Keyboard();

        public EnigmaMachine() { }
        public EnigmaMachine(IKeyboard keyboard) { _keyboard = keyboard; }

        public static EnigmaMachine Default() => new EnigmaMachine();

        public string Decrypt(string encryptedData)
        {
            throw new System.NotImplementedException();
        }

        public string Encrypt(string data)
        {
            throw new System.NotImplementedException();
        }
    }
}
