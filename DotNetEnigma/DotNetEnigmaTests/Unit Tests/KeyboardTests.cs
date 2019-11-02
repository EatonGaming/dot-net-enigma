using NUnit.Framework;
using DotNetEnigma.Enigma.Keyboard;
using FluentAssertions;

namespace DotNetEnigmaTests.Unit_Tests
{
    [TestFixture]
    public class KeyboardTests
    {
        [Test]
        public void Keyboard_InitializedWithStaticFactory_IsNotNull()
        {
            var keyboard = Keyboard.Default();

            keyboard
                .Should()
                .NotBeNull();
        }

        [Test]
        public void Keyboard_InitializedWithStaticFactory_ContainsAllRequiredKeys()
        {
            var keyboard = Keyboard.Default();

            keyboard
                .Keys
                .Should()
                .NotBeNullOrEmpty().And
                .HaveCount(26).And
                .AllBeOfType<Key>();
        }
    }
}
