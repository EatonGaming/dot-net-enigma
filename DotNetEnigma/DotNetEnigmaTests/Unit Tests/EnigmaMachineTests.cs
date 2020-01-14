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

        [Test]
        public void DefaultEnigmaMachine_EncryptText_DifferentTextReturned()
        {
            var textToEncrypt = "Text Information.";
            var enigmaMachine = EnigmaMachine.Default();

            var result = enigmaMachine.Encrypt(textToEncrypt);

            result.Should()
                .NotBe(textToEncrypt);
        }

        [Test]
        public void DefaultEnigmaMachine_DecryptText_DifferentTextReturned()
        {
            var textToDecrypt = "Text Information.";
            var enigmaMachine = EnigmaMachine.Default();

            var result = enigmaMachine.Decrypt(textToDecrypt);

            result.Should()
                .NotBe(textToDecrypt);
        }
    }
}
