﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetEnigma.Enigma.KeyProcessing.Rotors
{
    public class Rotor : IRotor
    {
        public char[] AvailableCharacters => GenerateAlphabetCharArray();
        public List<(char left, char right)> WiringConfiguration { get; set; }
        public RotorNumber RotorNumber { get; set; }
        public int NotchPosition { get; set; }

        public EventHandler<RotorStepEventArgs> RotorRequiresSteppingEvent;

        public Rotor() { }

        public Rotor(int notchPosition, RotorNumber rotorNumber, string wiringConfiguration, EventHandler<RotorStepEventArgs> RotorStepEvent)
        {
            NotchPosition = notchPosition;
            RotorNumber = rotorNumber;
            WiringConfiguration = ParseWiringConfiguration(wiringConfiguration);
            RotorRequiresSteppingEvent = RotorStepEvent;
        }

        public static Rotor Default() => new Rotor();

        public void Step()
        {
            var nextPosition = NotchPosition + 1;

            if (nextPosition > AvailableCharacters.Length - 1) //-1 offset to account for array indexing.
                nextPosition = 0;

            NotchPosition = nextPosition;
        }

        public char ProcessCharacter(char character, bool reverse)
        {
            if (!AvailableCharacters.Contains(character))
                throw new ArgumentException("Character provided to rotor does not appear in list of available characters.");

            if (RotorNumber == RotorNumber.I)
                Step();

            StepNextRotorIfRequired();

            if (!reverse)
            {
                var configuration = WiringConfiguration
                .Where(x => x.right == character)
                .FirstOrDefault();

                return configuration.left;
            }
            else
            {
                var configuration = WiringConfiguration
                .Where(x => x.left == character)
                .FirstOrDefault();

                return configuration.right;
            }
        }

        private void StepNextRotorIfRequired()
        {
            switch (RotorNumber)
            {

            }
        }

        private static char[] GenerateAlphabetCharArray()
        {
            var startIndex = 65;
            var endIndex = 90;
            var alphabet = new char[endIndex - startIndex + 1]; //+1 offset to account for array indexing.

            for (int i = startIndex; i <= endIndex; i++)
            {
                var currentCharacter = (char)i;
                alphabet[i - startIndex] = currentCharacter;
            }

            return alphabet;
        }

        private List<(char left, char right)> ParseWiringConfiguration(string wiringConfiguration)
        {
            var parsedOutput = new List<(char left, char right)>();

            for (int i = 0; i < AvailableCharacters.Length; i++)
            {
                var leftSideOfRotor = wiringConfiguration[i];
                var rightSideOfRotor = AvailableCharacters[i];

                parsedOutput.Add((leftSideOfRotor, rightSideOfRotor));
            }

            return parsedOutput;
        }
    }
}
