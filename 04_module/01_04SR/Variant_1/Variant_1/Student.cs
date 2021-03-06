﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Variant_1
{
    [Serializable]
    public class Student
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);

        private const int MinWorksLength = 5;
        private const int MaxWorksLength = 10;

        public string Name;
        public string Surname;

        public List<ControlElement> Works;

        public Student() { }

        /// <summary>
        /// Get amount of tasks.
        /// </summary>
        /// <returns> Amount of tasks </returns>
        private static int GetTasksNumber() =>
            Rnd.Next(Program.MinTasksNumber, Program.MaxTasksNumber + 1);

        /// <summary>
        /// Get weight of tasks.
        /// </summary>
        /// <returns> Weight of tasks </returns>
        private static int GetWeight() =>
            Rnd.Next(Program.MinWeight + 1, Program.MaxWeight + 1);

        /// <summary>
        /// Fill list of works.
        /// </summary>
        private void FillWorks()
        {
            var length = Rnd.Next(MinWorksLength, MaxWorksLength + 1);

            for (var i = 0; i < length; i++)
            {
                try
                {
                    if (Rnd.Next(2) == 0)
                    {
                        Works.Add(new Contest(GetWeight(), Program.GetRandomName(), GetTasksNumber()));
                    }
                    else
                    {
                        Works.Add(new ControlWork(GetWeight(), Program.GetRandomName(), Rnd.Next(2)));
                    }
                }
                catch (ArgumentException)
                {
                    i--;
                }
            }
        }

        internal Student(string name, string surname)
        {
            if (ControlElement.IsCorrectName(name) && ControlElement.IsCorrectName(surname))
            {
                (Name, Surname) = (name, surname);
            }
            else
            {
                throw new ArgumentException();
            }

            Works = new List<ControlElement>();
            FillWorks();
        }

        /// <summary>
        /// Return info about student.
        /// </summary>
        /// <returns> Info about student </returns>
        public override string ToString()
        {
            var result = $"Student name: {Name}, Surname: {Surname}\n";

            return Works.Aggregate(result, (current, work) => current + (work + "\n"));
        }
    }
}
