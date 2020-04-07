using System;

namespace MyLib
{
    [Serializable]
    public class Professor : Human
    {
        public Professor() { }
        public Professor(string name) : base(name) { }
    }
}