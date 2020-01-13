using DotNetEnigma.Enigma.KeyProcessing;
using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using DotNetEnigma.Enigma.Plugboard;
using DotNetEnigma.Utilities;
using System;

namespace DotNetEnigma.Enigma.Keyboard
{
    public class Keyboard : IKeyboard
    {
        private IPlugboard _plugboard;

        public Keyboard() {}

        public Keyboard(IPlugboard plugboard)
        {
            _plugboard = plugboard;
        }

        public static Keyboard Default() => new Keyboard();

        public event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;

        public void OnKeyPressed(Key keyPressed)
        {
            Guard.IsNotEqualTo(keyPressed, Key.Unknown, nameof(keyPressed));

            var keyToReturn = (_plugboard != null)
                ? _plugboard.ProcessKey(keyPressed)
                : keyPressed;
            var handler = KeyProvidedEvent;

            handler?.Invoke(this, new KeyPressedEventArgs() { KeyPressed = keyToReturn });
        }

        public void OnKeyPressed(char key)
        {
            Guard.IsNotNull(key, nameof(key));

            var convertedKey = ConvertToKey(key);

            OnKeyPressed(convertedKey);
        }

        private Key ConvertToKey(char character)
        {
            var uppercaseLetter = char.ToUpper(character);
            var asciiCodeOfLetter = (int)uppercaseLetter;

            if (Enum.IsDefined(typeof(Key), asciiCodeOfLetter))
            {
                return (Key)asciiCodeOfLetter;
            }
            else
            {
                throw new InvalidOperationException("Character provided does not match to character available on current keyboard.");
            }
        }
    }
}
