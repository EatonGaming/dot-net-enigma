using System.Collections.Generic;

namespace DotNetEnigma.Configuration.RotorWiringConfigurations
{
    public class WiringConfiguration
    {
        public string Configuration { get; set; }
        public int Rotor { get; set; }
    }

    public class EnigmaMachine
    {
        public string Name { get; set; }
        public List<WiringConfiguration> WiringConfigurations { get; set; }
    }

    public class RotorWiringConfiguration
    {
        public List<EnigmaMachine> EnigmaMachines { get; set; }
    }
}
