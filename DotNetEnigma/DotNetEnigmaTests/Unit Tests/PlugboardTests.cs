using NUnit.Framework;
using DotNetEnigma.Enigma.Plugboard;
using FluentAssertions;
using System.Collections.Generic;
using System;
using DotNetEnigma.Enigma.KeyProcessing.Keyboard;

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

            plugboard.PlugCableConfiguration.Should()
                .BeEmpty();
        }

        [Test]
        public void Plugboard_InitializedWithStaticFactoryConstructor_NoConfigurationSet()
        {
            var plugboard = Plugboard.Default();

            plugboard.PlugCableConfiguration.Should()
                .BeEmpty();
        }

        [Test]
        public void Plugboard_InitializedWithConfiguration_ConfigurationSet()
        {
            var plugCableConfiguration = MockData.plugboardTestConfiguration1;
            var plugboard = new Plugboard(plugCableConfiguration);

            plugboard.PlugCableConfiguration.Should()
                .BeEquivalentTo(plugCableConfiguration);
        }

        [Test]
        [TestCase(Key.A, Key.Z)]
        [TestCase(Key.D, Key.F)]
        [TestCase(null, Key.Z)]
        [TestCase(Key.A, null)]
        [TestCase(null, null)]
        [TestCase(Key.A, Key.A)]
        public void Plugboard_PlugCableAddedToConfiguration_ConfigurationChanged(Key key1, Key key2)
        {
            var plugboard = new Plugboard();
            var plugCable = new PlugCable(key1, key2);

            plugboard.InsertPlugCable(plugCable);

            plugboard.PlugCableConfiguration.Should()
                .Contain(plugCable).And
                .HaveCount(1);
        }

        [Test]
        public void Plugboard_AddPlugCableAlreadyAdded_ExceptionRaised()
        {
            var configuration = new List<PlugCable> { MockData.testPlugCableDifferentKeys1 };
            var plugboard = new Plugboard(configuration);

            Action act = () => plugboard.InsertPlugCable(MockData.testPlugCableDifferentKeys1);

            act.Should()
                .Throw<PlugboardConfigurationException>();
        }

        [Test]
        public void Plugboard_AddPlugCableKeyAlreadyConfigured_ExceptionRaised()
        {
            var plugCable1 = new PlugCable(Key.A, Key.C);
            var plugCable2 = new PlugCable(Key.A, Key.D);
            var configuration = new List<PlugCable> { plugCable1 };
            var plugboard = new Plugboard(configuration);

            Action act = () => plugboard.InsertPlugCable(plugCable2);

            act.Should()
                .Throw<PlugboardConfigurationException>();
        }

        [Test]
        [TestCase(Key.A, Key.Z)]
        [TestCase(Key.D, Key.F)]
        [TestCase(null, Key.Z)]
        [TestCase(Key.A, null)]
        [TestCase(null, null)]
        [TestCase(Key.A, Key.A)]
        public void Plugboard_PlugCableRemovedFromConfiguration_ConfigurationChanged(Key key1, Key key2)
        {
            var plugCable = new PlugCable(key1, key2);
            var configuration = new List<PlugCable>() { plugCable };
            var plugboard = new Plugboard(configuration);

            plugboard.RemovePlugCable(plugCable);

            plugboard.PlugCableConfiguration.Should()
                .NotContain(plugCable).And
                .HaveCount(0);
        }

        [Test]
        public void Plugboard_PlugCableConfigurationReset_ConfigurationCleared()
        {
            var plugboard = new Plugboard(MockData.plugboardTestConfiguration1);

            plugboard.ResetPlugCableConfiguration();

            plugboard.PlugCableConfiguration.Should()
                .BeEmpty();
        }

        [Test]
        public void Plugboard_PlugCableConfigurationSet_ConfigurationSet()
        {
            var plugboard = new Plugboard();

            plugboard.SetPlugCableConfiguration(MockData.plugboardTestConfiguration1);

            plugboard.PlugCableConfiguration.Should()
                .BeEquivalentTo(MockData.plugboardTestConfiguration1);
        }

        [Test]
        public void Plugboard_NullPlugCableConfigurationSet_ArgumentNullException()
        {
            var plugboard = new Plugboard();

            Action act = () => plugboard.SetPlugCableConfiguration(null);

            act.Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void PlugboardNotConfigured_KeyEntered_KeyEnteredTriggersEvent()
        {
            var plugboard = new Plugboard();
            var keyPressed = Key.A;

            var newKey = plugboard.ProcessKey(keyPressed);

            newKey.Should()
                .Be(keyPressed);
        }

        [Test]
        [TestCase(Key.A, Key.F, Key.A, Key.F)]
        [TestCase(Key.F, Key.A, Key.A, Key.F)]
        [TestCase(Key.A, Key.F, Key.F, Key.A)]
        public void PlugboardConfigured_KeyEntered_KeyEnteredTriggersEvent(Key plugA, Key plugB, Key keyEntered, Key keyReturned)
        {
            var configuration = new List<PlugCable>() { new PlugCable(plugA, plugB) };
            var plugboard = new Plugboard(configuration);

            var newKey = plugboard.ProcessKey(keyEntered);

            newKey.Should()
                .Be(keyReturned);
        }

        [Test]
        public void Plugboard_UnknownKeyEntered_ArgumentExceptionRaised()
        {
            var plugboard = new Plugboard();

            Action act = () => plugboard.ProcessKey(Key.Unknown);

            act.Should()
                .Throw<ArgumentException>();
        }
    }
}
