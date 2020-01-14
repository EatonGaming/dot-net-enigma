using DotNetEnigma.Enigma.KeyProcessing.Rotors;
using FluentAssertions;
using NUnit.Framework;

namespace DotNetEnigmaTests.Unit_Tests
{
    [TestFixture]
    class RotorUnitTests
    {
        [Test]
        public void Rotor_InitializedWithStaticFactory_IsNotNull()
        {
            var rotor = Rotor.Default();

            rotor.Should()
                .NotBeNull();
        }

        [Test]
        public void AvailableCharacters_OnRotorInitialisation_IsValidAlphabetArray()
        {
            var rotor = Rotor.Default();

            rotor.AvailableCharacters.Should()
                .NotBeNullOrEmpty().And
                .HaveCount(26).And
                .OnlyHaveUniqueItems().And
                .HaveElementAt(0, 'A').And
                .HaveElementAt(25, 'Z');
        }
    }
}
