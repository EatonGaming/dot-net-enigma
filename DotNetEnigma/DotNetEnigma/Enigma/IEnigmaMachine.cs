namespace DotNetEnigma.Enigma
{
    interface IEnigmaMachine
    {
        string Encrypt(string data);
        string Decrypt(string encryptedData);
    }
}
