using DotNetEnigma.Enigma.KeyProcessing;
using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using DotNetEnigma.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetEnigma.Enigma.Plugboard
{
    public class Plugboard : IPlugboard, IKeyProvider
    {
        private IKeyProvider _connectedKeyProvider;

        public ICollection<PlugCable> PlugCableConfiguration { get; private set; } = new List<PlugCable>();

        public Plugboard() { }

        public Plugboard(IKeyProvider keyProvider)
        {
            _connectedKeyProvider = keyProvider;

            _connectedKeyProvider.KeyProvidedEvent += HandleKeyProvided;
        }

        public Plugboard(ICollection<PlugCable> plugCableConfiguration)
        {
            PlugCableConfiguration = plugCableConfiguration;
        }

        public static IPlugboard Default() => new Plugboard();

        public event EventHandler<KeyPressedEventArgs> KeyProvidedEvent;

        public void HandleKeyProvided(object sender, KeyPressedEventArgs e)
        {
            OnKeyEntered(e.KeyPressed);
        }

        public void InsertPlugCable(PlugCable plugCable)
        {
            if (KeyAlreadyUsedByPlugCable(plugCable))
                throw new PlugboardConfigurationException("Key already specified in existing configuration.");

            PlugCableConfiguration.Add(plugCable);
        }

        private bool KeyAlreadyUsedByPlugCable(PlugCable plugCable)
        {
            var newPlugCable = new Key[] { plugCable.PlugA, plugCable.PlugB };

            return PlugCableConfiguration.Any(x => newPlugCable.Contains(x.PlugA) || newPlugCable.Contains(x.PlugB));
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

        public void OnKeyEntered(Key enteredKey)
        {
            Guard.IsNotEqualTo(enteredKey, Key.Unknown, nameof(enteredKey));

            var key = ProcessKey(enteredKey);
            var handler = KeyProvidedEvent;

            handler?.Invoke(this, new KeyPressedEventArgs() { KeyPressed = key });
        }

        private Key ProcessKey(Key keyToProcess)
        {
            var configuredPlugCable = GetPlugCableForKeyIfExists(keyToProcess);

            return (configuredPlugCable != null)
                ? (configuredPlugCable.PlugA == keyToProcess)
                    ? configuredPlugCable.PlugB
                    : configuredPlugCable.PlugA
                : keyToProcess;
        }

        private PlugCable GetPlugCableForKeyIfExists(Key key) => PlugCableConfiguration.SingleOrDefault(x => x.PlugA == key || x.PlugB == key);
    }
}
