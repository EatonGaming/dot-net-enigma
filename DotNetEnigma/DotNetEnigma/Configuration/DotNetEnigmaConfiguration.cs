using DotNetEnigma.Configuration.RotorWiringConfigurations;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace DotNetEnigma.Configuration
{
    public static class DotNetEnigmaConfiguration
    {
        private const string WiringConfigurationResourceName = "DotNetEnigma.Configuration.RotorWiringConfigurations.RotorWiringConfigurations.json";

        public static RotorWiringConfiguration RotorWiringConfiguration => LoadWiringConfigurations();

        private static RotorWiringConfiguration LoadWiringConfigurations()
        {
            using (var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(WiringConfigurationResourceName))
            {
                using (var source = new StreamReader(stream))
                {
                    var fileContents = source.ReadToEnd();

                    return JsonConvert.DeserializeObject<RotorWiringConfiguration>(fileContents);
                }
            }
        }
    }
}
