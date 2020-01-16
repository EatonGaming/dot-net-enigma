using DotNetEnigma.Configuration;
using System.Linq;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public class RotorSequenceBuilder : IRotorSequenceBuilder
    {
        private RotorSequence _instance = new RotorSequence();

        public void BuildReflector()
        {
            _instance.Reflector = new Reflector();
        }

        public void BuildRotor(RotorNumber number, int notchPosition)
        {
            var configuration = DotNetEnigmaConfiguration.RotorWiringConfiguration
                .EnigmaMachines.FirstOrDefault()
                    .WiringConfigurations.FirstOrDefault(x => x.Rotor == number);
            var newRotor = new Rotor(notchPosition, configuration.Rotor, configuration.Configuration);

            _instance.RotorSeries.Enqueue(newRotor);
        }

        public void Reset()
        {
            _instance = new RotorSequence();
        }

        public RotorSequence Assemble()
        {
            var instanceToReturn = _instance;

            Reset();

            return instanceToReturn;
        }
    }
}
