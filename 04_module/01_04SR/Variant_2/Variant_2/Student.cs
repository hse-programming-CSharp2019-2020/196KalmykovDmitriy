using System;
using System.Text.RegularExpressions;

namespace Variant_2
{
    [Serializable]
    internal class Student
    {
        private readonly string _name;
        private readonly string _surname;

        private Teacher _teacher;

        // ALTERNATIVE: Could we use common for-loop instead regex expression.

        /// <summary>
        /// Check name.
        /// </summary>
        /// <param name="name"> Name </param>
        /// <returns> True or false </returns>
        internal static bool IsCorrectName(string name)
        {
            var pattern = $@"^[А-Я][а-я]{{{name.Length - 1}}}";

            return Regex.IsMatch(name, pattern) 
                   && name.Length >= Program.MinNameLength
                   && name.Length <= Program.MaxNameLength;
        }

        internal Student(string name, string surname, Teacher teacher)
        {
            if (!(IsCorrectName(name) && IsCorrectName(surname)))
            {
                throw new ArgumentException();
            }

            _teacher = teacher;
            _name = name;
            _surname = surname;
        }

        /// <summary>
        /// Return info about student.
        /// </summary>
        /// <returns> Info about students </returns>
        public override string ToString() =>
            $"Student: Name = {_name}, Surname = {_surname}\n";
    }
}
