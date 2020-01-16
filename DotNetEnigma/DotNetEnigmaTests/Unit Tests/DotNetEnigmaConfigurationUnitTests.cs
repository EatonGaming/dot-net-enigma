using DotNetEnigma.Configuration;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetEnigmaTests.Unit_Tests
{
    [TestFixture]
    public class DotNetEnigmaConfigurationUnitTests
    {
        [Test]
        public void RotorWiringConfigurations_LoadFromJSONFile_FileDeserialisedSuccessfully()
        {
            var configurations = DotNetEnigmaConfiguration.RotorWiringConfiguration;

            configurations.EnigmaMachines.Should()
                .NotBeNull();
        }
    }
}
