using System;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Plugboard
{
    public class Plugboard : IPlugboard
    {
        public IEnumerable<KeyPair> KeyPairConfiguration { get; } = new List<KeyPair>();

        public Plugboard() { }

        public Plugboard(IEnumerable<KeyPair> keyPairConfiguration)
        {
            KeyPairConfiguration = keyPairConfiguration;
        }

        public static IPlugboard Default() => new Plugboard();

        public void AddKeyPair(KeyPair keyPair)
        {
            throw new NotImplementedException();
        }

        public void RemoveKeyPair(KeyPair keyPair)
        {
            throw new NotImplementedException();
        }

        public void ResetKeyPairConfiguration()
        {
            throw new NotImplementedException();
        }

        public void SetKeyPairConfiguration(IEnumerable<KeyPair> newKeyPairConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}
