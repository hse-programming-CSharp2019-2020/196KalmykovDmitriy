using System;
using System.Linq;

namespace Task_3
{
    internal class Methods
    {
        /// <summary>
        /// Print info about suitable figures.
        /// </summary>
        /// <typeparam name="T"> Type of figures </typeparam>
        /// <param name="figures"> Array of figures </param>
        /// <param name="bound"> Bound of figure's area </param>
        public static void PorArea<T>(T[] figures, double bound)
            where T : IFigure
        {
            var suitableFigures = from figure in figures
                                    where figure.GetArea > bound
                                    select figure;

            foreach (var figure in suitableFigures)
            {
                Console.WriteLine(figure.ToString());
            }
        }
    }
}
