using System;

namespace Variant_2
{
    [Serializable]
    internal class Teacher
    {
        private readonly string _name;
        private readonly string _surname;
        private readonly string _subject;

        private readonly int _classesNumber;

        /// <summary>
        /// Check values.
        /// </summary>
        /// <param name="name"> Name </param>
        /// <param name="surname"> Surname </param>
        /// <param name="subject"> Subject </param>
        /// <param name="classesNumber"> Classes number </param>
        /// <returns> True or false </returns>
        private bool IsValidValues(string name, string surname, string subject, int classesNumber) =>
                                           Student.IsCorrectName(name)
                                        && Student.IsCorrectName(surname)
                                        && Student.IsCorrectName(subject)
                                        && classesNumber >= Program.MinClassesNumber
                                        && classesNumber <= Program.MaxClassesNumber;

        internal Teacher(string name, string surname, string subject, int classesNumber)
        {
            if (!IsValidValues(name, surname, subject, classesNumber))
            {
                throw new ArgumentException();
            }

            _name = name;
            _surname = surname;
            _subject = subject;
            _classesNumber = classesNumber;
        }

        /// <summary>
        /// Return info about teacher.
        /// </summary>
        /// <returns> Info about teacher </returns>
        public override string ToString() =>
            $"Teacher: Name = {_name}, Surname = {_surname}, Subject = {_subject}," +
            $"classes number = {_classesNumber}";
    }
}
