using System;

namespace Inhabitants
{
    /// <summary>
    /// Class Human.
    /// </summary>
    public class Human : Creature
    {
        // Property.
        public string Name { get; private set; }
        public sealed override string Location { get; set; }

        // Constructor.
        public Human(string name, string location) =>
            (Name, Location) = (name, location);

        /// <summary>
        /// Overriden method of creatures.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine("Моё место положение: " + Location);
            Location = Location;
            Console.WriteLine($"{Name} >> Волшебник {((Wizard)sender).Name}" +
                              $"позвал. Моя цель { e.Message}");
        }
    }
}
