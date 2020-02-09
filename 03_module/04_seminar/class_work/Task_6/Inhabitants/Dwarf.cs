using System;

namespace Inhabitants
{
    /// <summary>
    /// Class Dwarf.
    /// </summary>
    public class Dwarf : Creature
    {
        // Property.
        public string Name { get; private set; }
        public sealed override string Location { get; set; }

        // Constructor.
        public Dwarf(string name, string location) =>
            (Name, Location) = (name, location);

        /// <summary>
        /// Overriden method of cretures.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine("Моё место положение: " + Location);
            Console.WriteLine($"{Name} >> Точим топоры, собираем припасы! " +
            "Выдвигаемся в " + e.Message);
        }
    }
}
