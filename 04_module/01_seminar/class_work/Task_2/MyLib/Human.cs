using System;

namespace MyLib
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human() { }

        // Constructor.
        public Human(string name) =>
            Name = name;
    }
}