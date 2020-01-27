using DotNetEnigma.Enigma;
using FluentAssertions;
using NUnit.Framework;

namespace DotNetEnigmaTests.Unit_Tests
{
    [TestFixture]
    public class EnigmaMachineTests
    {
        [Test]
        public void EnigmaMachine_InitializedWithStaticFactory_IsNotNull()
        {
            var enigmaMachine = EnigmaMachine.Default();

            enigmaMachine.Should()
                .NotBeNull();
        }
    }
}
