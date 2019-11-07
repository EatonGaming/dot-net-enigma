using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using System.Collections.Generic;

namespace DotNetEnigma.Enigma.Plugboard
{
    public interface IPlugboard
    {
        ICollection<PlugCable> PlugCableConfiguration { get; }

        void OnKeyEntered(Key key);

        void InsertPlugCable(PlugCable keyPair);
        void RemovePlugCable(PlugCable keyPair);
        void SetPlugCableConfiguration(ICollection<PlugCable> newKeyPairConfiguration);
        void ResetPlugCableConfiguration();
    }
}
