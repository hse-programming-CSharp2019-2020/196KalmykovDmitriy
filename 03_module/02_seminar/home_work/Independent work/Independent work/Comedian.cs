using System;
using System.Linq;
using System.Text;

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
            if (NameIsWrong(name))
                throw new Exception("Name must contain only letters, first letter is upper");

            _name = name;
        }

        /// <summary>
        /// Check name for correct.
        /// </summary>
        /// <param name="name"> Name </param>
        /// <returns> True or false </returns>
        private static bool NameIsWrong(string name)
        {
            // Check for null.
            if (name is null)
                return true;

            var stringBuilder = new StringBuilder(name);

            // Check first letter.
            if (!char.IsUpper(stringBuilder[0]))
                return true;

            // Delete first letter, so we can check other.
            stringBuilder.Remove(0, 1);

            return !stringBuilder.ToString().All(char.IsLower);
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