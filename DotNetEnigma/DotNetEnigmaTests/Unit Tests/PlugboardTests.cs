using NUnit.Framework;
using DotNetEnigma.Enigma.Plugboard;
using FluentAssertions;

namespace DotNetEnigmaTests.Unit_Tests
{
    [TestFixture]
    public class PlugboardTests
    {
        [Test]
        public void Plugboard_InitializedWithConstructor_NotNull()
        {
            var plugboard = new Plugboard();

            plugboard.Should()
                .NotBeNull();
        }

        [Test]
        public void Plugboard_InitializedWithStaticFactory_NotNull()
        {
            var plugboard = Plugboard.Default();

            plugboard.Should()
                .NotBeNull();
        }

        [Test]
        public void Plugboard_InitializedWithDefaultConstructor_NoConfigurationSet()
        {
            var plugboard = new Plugboard();

            plugboard.KeyPairConfiguration.Should()
                .BeEmpty();
        }

        [Test]
        public void Plugboard_InitializedWithStaticFactoryConstructor_NoConfigurationSet()
        {
            var plugboard = Plugboard.Default();

            plugboard.KeyPairConfiguration.Should()
                .BeEmpty();
        }

        [Test]
        public void Plugboard_InitializedWithConfiguration_ConfigurationSet()
        {
            var keyPairConfiguration = MockData.plugboardTestConfiguration1;
            var plugboard = new Plugboard(keyPairConfiguration);

            plugboard.KeyPairConfiguration.Should()
                .BeEquivalentTo(keyPairConfiguration);
        }
    }
}
