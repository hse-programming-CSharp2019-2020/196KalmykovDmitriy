using System;

namespace MyLib
{
    [Serializable]
    public class Student
    {
        // Info about student.
        public string Name;
        public int Year;

        public Student() { }

        public Student(string name, int year) =>
            (Name, Year) = (name, year);
    }
}