using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLib
{
    [Serializable]
    public class Group
    {
        // Group's identifier.
        public string Identifier;

        // List of students.
        public List<Student> Students;

        public Group() { }

        public Group(string identifier, List<Student> students) =>
            (Identifier, Students) = (identifier, students);

        /// <summary>
        /// Return info about group.
        /// </summary>
        /// <returns> Info about students </returns>
        public override string ToString()
        {
            var result = $"{Identifier}: ";

            return Students.Aggregate(result,
                (current, student) => current + (student.Name + "-" + student.Year + " "));
        }
    }
}