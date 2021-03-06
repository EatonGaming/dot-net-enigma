﻿using DotNetEnigma.Enigma.KeyProcessing.Rotors;
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
            var rotor = new Rotor(startNotchPosition, RotorNumber.I, MockData.DefaultWiringConfiguration);

            rotor.Step();

            rotor.NotchPosition.Should()
                .Be(expectedPostStepNotchPosition);
        }

        [Test]
        public void ParseWiringConfiguration_ValuePassedOnConstruction_ConfigurationParsedSuccessfully()
        {
            var configuration = "QWERTYUIOPASDFGHJKLZXCVBNM";
            var rotor = new Rotor(0, RotorNumber.I, configuration);

            rotor.WiringConfiguration.Should()
                .NotBeNullOrEmpty().And
                .HaveCount(26).And
                .ContainSingle(x => x.right == 'A' && x.left == 'Q').And
                .ContainSingle(x => x.right == 'Z' && x.left == 'M');
        }

        [Test]
        [TestCase('A', 'Q', false)]
        [TestCase('Q', 'A', true)]
        [TestCase('M', 'D', false)]
        [TestCase('D', 'M', true)]
        [TestCase('T', 'Z', false)]
        [TestCase('Z', 'T', true)]
        public void ProcessCharacter_ValidCharacterPassed_CorrectCharacterReturned(char characterToProcess, char expectedResult, bool reverse)
        {
            // ----------------- ABCDEFGHIJKLMNOPQRSTUVWXYZ
            var configuration = "QWERTYUIOPASDFGHJKLZXCVBNM";
            var rotor = new Rotor(0, RotorNumber.I, configuration);

            var result = rotor.ProcessCharacter(characterToProcess, reverse);

            result.Should()
                .Be(expectedResult);
        }
    }
}
