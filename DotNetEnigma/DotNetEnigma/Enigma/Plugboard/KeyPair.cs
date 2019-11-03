using DotNetEnigma.Enigma.Keyboard;

namespace DotNetEnigma.Enigma.Plugboard
{
    public class KeyPair
    {
        public Key SourceKey { get; }
        public Key TargetKey { get; }

        public KeyPair(Key sourceKey, Key targetKey)
        {
            SourceKey = sourceKey;
            TargetKey = targetKey;
        }
    }
}
