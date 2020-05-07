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

        [Test]
        [TestCase('a', Key.A)]
        [TestCase('N', Key.N)]
        [TestCase('f', Key.F)]
        public void Keyboard_ValidCharProvided_ConvertedKeyReturned(char providedCharacter, Key expectedKeyReturned)
        {
            var keyboard = new Keyboard();

            using var monitoredSubject = keyboard.Monitor();
            keyboard.OnKeyPressed(providedCharacter);

            monitoredSubject.Should()
                .Raise(nameof(IKeyboard.KeyProvidedEvent))
                .WithArgs<KeyPressedEventArgs>(x => x.KeyPressed == expectedKeyReturned);
        }

        [Test]
        [TestCase('\0')]
        [TestCase('7')]
        [TestCase('>')]
        public void Keyboard_InvalidCharProvided_InvalidOperationExceptionRaised(char providedCharacter)
        {
            var keyboard = new Keyboard();

            Action act = () => keyboard.OnKeyPressed(providedCharacter);

            act.Should()
                .Throw<InvalidOperationException>();
        }

        [Test]
        public void ValidKeyNoPlugboard_KeyPressed_SameKeyReturned()
        {
            var keyboard = new Keyboard();
            var key = Key.A;
            var expected = key;

            Key actual = keyboard.PressKey(key);

            actual.Should().Be(expected);
        }


        [Test]
        public void ValidKeyPlugboard_KeyPressed_SameKeyReturned()
        {
            var configuration = new List<PlugCable>() { new PlugCable(Key.A, Key.C) };
            var plugboard = new Plugboard(configuration);
            var keyboard = new Keyboard(plugboard);
            var key = Key.A;
            var expected = Key.C;

            Key actual = keyboard.PressKey(key);

            actual.Should().Be(expected);
        }

        [Test]
        public void ValidKeyNoPlugboard_KeyPressedChar_SameKeyReturned()
        {
            var keyboard = new Keyboard();
            var key = (char)65;
            var expected = key;

            Key actual = keyboard.PressKey(key);

            actual.Should().Be(expected);
        }
    }
}
