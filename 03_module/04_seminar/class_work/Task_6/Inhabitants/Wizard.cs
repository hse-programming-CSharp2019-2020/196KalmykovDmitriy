using System;

namespace Inhabitants
{
    /// <summary>
    /// Class Wizard.
    /// </summary>
    public class Wizard : Creature
    {
        // Property.
        public string Name { get; private set; }
        public sealed override string Location { get; set; }

        public event EventHandler<RingIsFoundEventArgs> RaiseRingIsFoundEvent;

        // Constructor.
        public Wizard(string name, string location) =>
            (Name, Location) = (name, location);

        /// <summary>
        /// Raise event.
        /// </summary>
        public void SomeThisIsChangedInTheAir()
        {
            Console.WriteLine($"Моё место положение: {Location}");

            Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! " +
                              "Призываю вас в Ривендейл! \n");

            RaiseRingIsFoundEvent?.Invoke(this, new RingIsFoundEventArgs(
                "Ривендейл\n"));
        }

        /// <summary>
        /// Overriden method of creatures.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
        }
    }
}
