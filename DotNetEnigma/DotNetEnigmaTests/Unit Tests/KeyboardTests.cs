using NUnit.Framework;
using DotNetEnigma.Enigma.Keyboard;
using FluentAssertions;
using System;

namespace DotNetEnigmaTests.Unit_Tests
{
    [TestFixture]
    public class KeyboardTests
    {
        private readonly int _numberOfKeys = Enum.GetNames(typeof(Key)).Length;

        [Test]
        public void Keyboard_InitializedWithStaticFactory_IsNotNull()
        {
            var keyboard = Keyboard.Default();

            keyboard.Should()
                .NotBeNull();
        }

        [Test]
        public void Keyboard_InitializedWithStaticFactory_ContainsAllRequiredKeys()
        {
            var keyboard = Keyboard.Default();

            keyboard.Keys.Should()
                .NotBeNullOrEmpty().And
                .HaveCount(_numberOfKeys).And
                .AllBeOfType<Key>();
        }

        [Test]
        public void Keyboard_InitializedWithConstructor_ContainsAllRequiredKeys()
        {
            var keyboard = new Keyboard();

            keyboard.Keys.Should()
                .NotBeNullOrEmpty().And
                .HaveCount(_numberOfKeys).And
                .AllBeOfType<Key>();
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
                .Raise(nameof(IKeyboard.KeyPressedEvent))
                .WithArgs<KeyPressedEventArgs>(x => x.KeyPressed == keyPressed);
        }

        [Test]
        [TestCase(null)]
        [TestCase(Key.Unknown)]
        public void Keyboard_InvalidKeyPressed_ArgumentNullExceptionRaised(Key keyPressed)
        {
            var keyboard = Keyboard.Default();

            Action act = () => keyboard.OnKeyPressed(keyPressed);

            act.Should()
                .Throw<ArgumentNullException>();
        }
    }
}
