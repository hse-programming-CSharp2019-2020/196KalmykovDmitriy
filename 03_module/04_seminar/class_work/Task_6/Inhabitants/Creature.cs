namespace Inhabitants
{
    /// <summary>
    /// Class Creature.
    /// </summary>
    public abstract class Creature
    {
        // Location.
        public abstract string Location { get; set; }

        /// <summary>
        /// Event Handler.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public abstract void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e);
    }
}
