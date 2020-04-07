using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLib
{
    [Serializable]
    public class Multiple
    {
        // Names of digits.
        private readonly List<string> _names = new List<string>
        {
            "one", "two", "three",
            "four", "five", "six",
            "seven", "eight", "nine"
        };

        public Multiple() { }

        public Multiple(int divisor, List<int> numbers)
        {
            if (divisor <= 0 || divisor > 9)
            {
                throw new Exception("Wrong value of divisor!");
            }

            Divisor = divisor;
            Name = _names[divisor - 1];

            Numbers.AddRange(numbers.FindAll(number => number % divisor == 0));
        }

        // Divisor's name.
        public string Name { get; set; }

        // Divisor's value.
        public int Divisor { get; set; }

        // List of numbers multiple divisors.
        public readonly List<int> Numbers = new List<int>();

        /// <summary>
        /// Return info about multiple.
        /// </summary>
        /// <returns> Info about multiple </returns>
        public override string ToString()
        {
            var result = $"Divisor: {Divisor} - {Name}\r\nMultiple: ";

            return Numbers.Aggregate(result, (current, next) => current + next + " ",
                res => res + Environment.NewLine);
        }
    }
}