using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Plugboard
{
    public interface IPlugboard
    {
        IEnumerable<KeyPair> KeyPairConfiguration { get; }

        void AddKeyPair(KeyPair keyPair);
        void RemoveKeyPair(KeyPair keyPair);
        void SetKeyPairConfiguration(IEnumerable<KeyPair> newKeyPairConfiguration);
        void ResetKeyPairConfiguration();
    }
}
