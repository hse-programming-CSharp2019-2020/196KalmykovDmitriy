using System;
using System.Text.RegularExpressions;

namespace Variant_1
{
    [Serializable]
    public class ControlElement
    {
        public int Weight;
        public string Name;

        public ControlElement() { }

        // ALTERNATIVE: Could we use common for-loop instead regex expression.

        /// <summary>
        /// Check name.
        /// </summary>
        /// <param name="name"> Name </param>
        /// <returns> True or false </returns>
        internal static bool IsCorrectName(string name)
        {
            var pattern = $@"^[А-Я][а-я]{{{name.Length - 1}}}";

            return Regex.IsMatch(name, pattern) && name.Length >= 2 && name.Length <= 12;
        }

        /// <summary>
        /// Check values.
        /// </summary>
        /// <param name="weight"> Weight of task </param>
        /// <param name="name"> Name of test </param>
        /// <returns> True of false </returns>
        private bool IsCorrectValues(int weight, string name) =>
            weight > 0 && weight <= 80 && IsCorrectName(name);

        internal ControlElement(int weight, string name)
        {
            if (!IsCorrectValues(weight, name))
                throw new ArgumentOutOfRangeException();

            Weight = weight;
            Name = name;
        }

        /// <summary>
        /// Return info about control element.
        /// </summary>
        /// <returns> Info about control element </returns>
        public override string ToString() =>
            $"Weight = {Weight}, name = {Name}";
    }
}
