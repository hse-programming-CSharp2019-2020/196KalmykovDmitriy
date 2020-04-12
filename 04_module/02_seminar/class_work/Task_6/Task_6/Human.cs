using System;
using System.Xml.Serialization;

namespace Task_6
{
    [Serializable]
    public class Human
    {
        [XmlAttribute("HumanName")]

        public string Name { get; set; }

        public Human() { }

        public Human(string name) =>
            Name = name;
    }
}
