using System;
using System.Linq;

namespace Independent_work
{
    /// <summary>
    /// Class comedian.
    /// </summary>
    internal class Comedian
    {
        // Name.
        private readonly string _name;

        // Как альтернатива, проверку имени можно было вынести в отдельный метод,
        // в котором бы проходили циклом по всему имени и проверяли каждый символ.
        // Constructor.
        internal Comedian(string name)
        {
            if (name is null || name.ToCharArray().Any(char.IsDigit))
                throw new Exception("Name must not contain digits");

            _name = name;
        }

        /// <summary>
        /// Print info about comedian.
        /// </summary>
        internal void Identify() =>
            Program.PrintMessage($"Я комик, меня зовут {_name}.\n", ConsoleColor.Yellow);

        /// <summary>
        /// Print joke.
        /// </summary>
        internal static void Joke() =>
            Program.PrintMessage("Я не слечу с бюджета");
    }
}