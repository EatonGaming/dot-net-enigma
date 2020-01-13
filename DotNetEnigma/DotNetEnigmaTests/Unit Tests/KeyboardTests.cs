using NUnit.Framework;
using DotNetEnigma.Enigma.Keyboard;
using FluentAssertions;
using System;
using DotNetEnigma.Enigma.KeyProcessing;
using DotNetEnigma.Enigma.KeyProcessing.Keyboard;
using DotNetEnigma.Enigma.Plugboard;
using System.Collections.Generic;

namespace DotNetEnigmaTests.Unit_Tests
{
    [TestFixture]
    public class KeyboardTests
    {
        [Test]
        public void Keyboard_InitializedWithStaticFactory_IsNotNull()
        {
            var keyboard = Keyboard.Default();

            keyboard.Should()
                .NotBeNull();
        }

        [Test]
        [TestCase(Key.A)]
        [TestCase(Key.J)]
        [TestCase(Key.Z)]
        public void Keyboard_PressedKey_KeyPressedTriggersEvent(Key keyPressed)
        {
            var keyboard = Keyboard.Default();

            using var monitoredSubject = keyboard.Monitor();
            keyboard.OnKeyPressed(keyPressed);

            monitoredSubject.Should()
                .Raise(nameof(IKeyboard.KeyProvidedEvent))
                .WithArgs<KeyPressedEventArgs>(x => x.KeyPressed == keyPressed);
        }

        [Test]
        [TestCase(null)]
        [TestCase(Key.Unknown)]
        public void Keyboard_InvalidKeyPressed_ArgumentExceptionRaised(Key keyPressed)
        {
            var keyboard = Keyboard.Default();

            Action act = () => keyboard.OnKeyPressed(keyPressed);

            act.Should()
                .Throw<ArgumentException>();
        }

        [Test]
        [TestCase(Key.A)]
        [TestCase(Key.F)]
        public void KeyboardWithPlugboard_KeyPressedNoConfiguration_KeyReturned(Key keyPressed)
        {
            var plugboard = new Plugboard();
            var keyboard = new Keyboard(plugboard);

            using var monitoredSubject = keyboard.Monitor();
            keyboard.OnKeyPressed(keyPressed);

            monitoredSubject.Should()
                .Raise(nameof(IKeyboard.KeyProvidedEvent))
                .WithArgs<KeyPressedEventArgs>(x => x.KeyPressed == keyPressed);
        }

        [Test]
        [TestCase(Key.A, Key.C)]
        [TestCase(Key.C, Key.A)]
        [TestCase(Key.D, Key.I)]
        [TestCase(Key.I, Key.D)]
        [TestCase(Key.F, Key.F)]
        [TestCase(Key.N, Key.N)]
        public void KeyboardWithPlugboard_KeyPressedWithConfiguration_ModifiedKeyReturned(Key keyPressed, Key expectedKeyReturned)
        {
            var configuration = new List<PlugCable>() { new PlugCable(Key.A, Key.C), new PlugCable(Key.D, Key.I) };
            var plugboard = new Plugboard(configuration);
            var keyboard = new Keyboard(plugboard);

            using var monitoredSubject = keyboard.Monitor();
            keyboard.OnKeyPressed(keyPressed);

            monitoredSubject.Should()
                .Raise(nameof(IKeyboard.KeyProvidedEvent))
                .WithArgs<KeyPressedEventArgs>(x => x.KeyPressed == expectedKeyReturned);
        }
    }
}
