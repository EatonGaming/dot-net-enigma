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

        [Test]
        [TestCase(0, 1)]
        [TestCase(15, 16)]
        [TestCase(22, 23)]
        [TestCase(25, 0)]
        public void NotchPosition_StepRotor_NotchPositionIsCorrectAfterStep(int startNotchPosition, int expectedPostStepNotchPosition)
        {
            var rotor = new Rotor(startNotchPosition, 1);

            rotor.Step();

            rotor.NotchPosition.Should()
                .Be(expectedPostStepNotchPosition);
        }
    }
}
