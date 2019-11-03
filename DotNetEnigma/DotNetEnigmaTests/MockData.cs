using DotNetEnigma.Enigma.Keyboard;
using DotNetEnigma.Enigma.Plugboard;
using System.Collections.Generic;

namespace DotNetEnigmaTests
{
    public static class MockData
    {
        public static IEnumerable<KeyPair> plugboardTestConfiguration1 = new List<KeyPair>() { 
            new KeyPair(Key.A, Key.H), 
            new KeyPair(Key.L, Key.V) 
        };
    }
}
