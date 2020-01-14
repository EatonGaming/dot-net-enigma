using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using DotNetEnigma.Enigma.Plugboard;
using System.Collections.Generic;

namespace DotNetEnigmaTests
{
    public static class MockData
    {
        public static ICollection<PlugCable> plugboardTestConfiguration1 = new List<PlugCable>() { 
            new PlugCable(Key.A, Key.H), 
            new PlugCable(Key.L, Key.V) 
        };

        public static PlugCable testPlugCableDifferentKeys1 = new PlugCable(Key.A, Key.Z);
        public static PlugCable testPlugCableDifferentKeys2 = new PlugCable(Key.F, Key.H);
        public static PlugCable testPlugCableDifferentKeys3 = new PlugCable(Key.Unknown, Key.A);
        public static PlugCable testPlugCableDifferentKeys4 = new PlugCable(Key.A, Key.Unknown);
        public static PlugCable testPlugCableSameKey1 = new PlugCable(Key.A, Key.A);

        public static string DefaultWiringConfiguration = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
