using System;

namespace DotNetEnigma.Enigma.KeyProcessing
{
    public interface IExposeKeyPressed
    {
        event EventHandler KeyPressedEvent;
    }
}
