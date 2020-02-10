using Inhabitants;
using System;
using System.Collections.Generic;

namespace Task_6
{
    internal class Program
    {
        /// <summary>
        /// Get hobbits.
        /// </summary>
        /// <returns> List from hobbits </returns>
        private static IEnumerable<Hobbit> GetHobbits()
        {
            // Hobbit's names.
            string[] hobbitNames = { "Фродо", "Сэм", "Пипин", "Мэрри" };
            var hobbits = new Hobbit[4];

            // Crete new hobbits.
            for (var i = 0; i < hobbits.Length; i++)
                hobbits[i] = new Hobbit(hobbitNames[i], "Шир");

            return hobbits;
        }

        /// <summary>
        /// Get all creatures.
        /// </summary>
        /// <returns> List from creatures </returns>
        private static IEnumerable<Creature> GetAllCreatures()
        {
            var creatures = new List<Creature>();

            // Create creatures.
            var hobbits = GetHobbits();
            Human[] humans =
            {
                new Human("Боромир", "Широколиственный лес"),
                new Human("Арагорн", "Тундра")
            };
            var dwarf = new Dwarf("Гимли", "Нора");
            var elf = new Elf("Леголас", "Пещера");

            // Add all creature to list.
            creatures.AddRange(hobbits);
            creatures.AddRange(humans);
            creatures.Add(dwarf);
            creatures.Add(elf);

            return creatures;
        }

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void Main()
        {
            // Create wizard.
            var wizard = new Wizard("Гендальф", "Хогварц");

            // Get all creatures.
            var creatures = GetAllCreatures();

            // Subscribe to the event.
            foreach (var creature in creatures)
                wizard.RaiseRingIsFoundEvent += creature.RingIsFoundEventHandler;

            // Raise event.
            wizard.SomeThisIsChangedInTheAir();

            PrintMessage("Press ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) 
            {
            }
        }
    }
}
