using System;

namespace Task_3
{
    // Delegates.
    internal delegate void ChainLenChanged(double r);
    internal delegate void ChainNChanged(int amount, double len);
    internal delegate void ChainRChanged(double r);

    internal class Program
    {
        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> conditions)
            where T : new()
        {
            Console.Write(message);

            while (true)
            {
                try
                {
                    // Attempt to get number.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check conditions.
                    if (conditions(result))
                        return result;

                    PrintMessage("Number must be > 0\n", ConsoleColor.Yellow);
                    Console.Write(message);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data\n", ConsoleColor.Red);
                    Console.Write(message);
                }
            }
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

        /// <summary>
        /// Get number from user (1 or 2 or 3).
        /// </summary>
        /// <returns> 1 or 2 or 3 </returns>
        private static int GetChoice()
        {
            int choice;

            Console.WriteLine("Enter 1 to change the length of the chain,\n" +
                              "Enter 2 to change amount of beads\n" +
                              "Enter 3 to change radius of bead");

            // Get choice.
            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice != 1 && choice != 2 && choice != 3)
                PrintMessage("Enter 1 or 2 or 3!\n");

            return choice;
        }

        /// <summary>
        /// Processing of choice.
        /// </summary>
        /// <param name="choice"> 1 or 2 or 3 </param>
        /// <param name="chain"> Chain from beads </param>
        private static void Processing(int choice, Chain chain)
        {
            switch (choice)
            {
                case 1:
                    // Get new length.
                    var length = GetNumber<double>("Enter new length of chain: ",
                        el => el > 0);

                    // Set new length.
                    chain.Len = length;
                    break;

                case 2:
                    // Get new amount.
                    var n = GetNumber<int>("Enter new amount of beads: ",
                        el => el > 0);

                    // Set new amount.
                    chain.N = n;
                    break;

                case 3:
                    // Get new radius.
                    var r = GetNumber<int>("Enter new radius of bead: ",
                        el => el > 0);

                    // Set new radius.
                    chain.ChangeRWithEvent(r);
                    break;
            }

            PrintMessage(chain.ToString(), ConsoleColor.Yellow);
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                // Get amount of chain.
                var n = GetNumber<int>("Enter amount of beads: ",
                    el => el > 0);

                // Get length of chain.
                var length = GetNumber<double>("Enter length of chain: ",
                    el => el > 0);

                // Create new cain.
                var chain = new Chain(length, n);

                // Subscribe methods to events.
                chain.ChainLenChangedEvent += chain.ChangeLen;
                chain.ChainNChangedEvent += new Bead(10).ChangeN;
                chain.ChainRChangedEvent += chain.ChangeR;

                PrintMessage(chain.ToString(), ConsoleColor.Yellow);

                var choice = GetChoice();

                Processing(choice, chain);

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
