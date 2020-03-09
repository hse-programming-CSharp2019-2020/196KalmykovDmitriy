using System;

namespace Task_2
{
    internal struct Person
    {
        // User information.
        private int _age;
        internal string Name { get; set; }
        internal string Lastname { get; set; }

        internal int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Age must be >= 0: ");

                _age = value;
            }
        }

        // Constructor.
        internal Person(string name, string lastname, int age)
        {
            Name = name;
            Lastname = lastname;
            _age = age;
        }

        /// <summary>
        /// Return info about user.
        /// </summary>
        /// <returns> Info about user </returns>
        public override string ToString() =>
            $"{Name} {Lastname} {Age}";
    }
}
