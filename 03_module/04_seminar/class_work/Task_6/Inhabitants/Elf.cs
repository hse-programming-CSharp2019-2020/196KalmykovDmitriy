using System;

namespace Inhabitants
{
    /// <summary>
    /// Class elf.
    /// </summary>
    public class Elf : Creature
    {
        // Property.
        public string Name { get; private set; }
        public sealed override string Location { get; set; }

        // Constructor.
        public Elf(string name, string location) =>
            (Name, Location) = (name, location);

        /// <summary>
        /// Overriden method of cretures.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine("Моё место положение: " + Location);
            Location = Location;
            Console.WriteLine($"{Name} >> Звёзды светят не так ярко как обычно. " +
                              "Цветы увядают. Листья предсказывают идти в " + e.Message);
        }
    }
}
