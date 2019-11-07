using DotNetEnigma.Enigma.KeyProcessing.Keyboard;

namespace DotNetEnigma.Enigma.Plugboard
{
    public class PlugCable
    {
        public PlugCable(Key plugA, Key plugB)
        {
            PlugA = plugA;
            PlugB = plugB;
        }

        public Key PlugA { get; }
        public Key PlugB { get; }
    }
}
