using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using DotNetEnigma.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace DotNetEnigma.Enigma.Plugboard
{
    public class Plugboard : IPlugboard
    {
        public Plugboard() { }

        public Plugboard(ICollection<PlugCable> plugCableConfiguration)
        {
            PlugCableConfiguration = plugCableConfiguration;
        }

        public static IPlugboard Default() => new Plugboard();

        public ICollection<PlugCable> PlugCableConfiguration { get; private set; } = new List<PlugCable>();

        public void InsertPlugCable(PlugCable plugCable)
        {
            if (KeyAlreadyUsedByPlugCable(plugCable))
                throw new PlugboardConfigurationException("Key already specified in existing configuration.");

            PlugCableConfiguration.Add(plugCable);
        }

        public void RemovePlugCable(PlugCable plugCable)
        {
            PlugCableConfiguration.Remove(plugCable);
        }

        public void ResetPlugCableConfiguration()
        {
            PlugCableConfiguration.Clear();
        }

        public void SetPlugCableConfiguration(ICollection<PlugCable> newPlugCableConfiguration)
        {
            Guard.IsNotNull(newPlugCableConfiguration, nameof(newPlugCableConfiguration));

            PlugCableConfiguration = newPlugCableConfiguration;
        }

        public Key ProcessKey(Key enteredKey)
        {
            Guard.IsNotEqualTo(enteredKey, Key.Unknown, nameof(enteredKey));

            return ApplyConfigurationToKey(enteredKey);
        }

        private bool KeyAlreadyUsedByPlugCable(PlugCable plugCable)
        {
            var newPlugCable = new Key[] { plugCable.PlugA, plugCable.PlugB };

            return PlugCableConfiguration.Any(x => newPlugCable.Contains(x.PlugA) || newPlugCable.Contains(x.PlugB));
        }

        private Key ApplyConfigurationToKey(Key keyToProcess)
        {
            var configuredPlugCable = GetPlugCableForKeyIfExists(keyToProcess);

            if (configuredPlugCable == null)
            {
                return keyToProcess;
            }
            else if (configuredPlugCable.PlugA == keyToProcess)
            {
                return configuredPlugCable.PlugB;
            }
            else
            {
                return configuredPlugCable.PlugA;
            }
        }

        private PlugCable GetPlugCableForKeyIfExists(Key key) => PlugCableConfiguration.SingleOrDefault(x => x.PlugA == key || x.PlugB == key);
    }
}
