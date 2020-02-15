using System;

namespace MyLib
{
    /// <summary>
    /// Class Block.
    /// </summary>
    public class Block
    {
        private double _height;

        // Base of block.
        private Rectangle Base { get; }

        // Constructor.
        public Block(Rectangle rectangle, double height) =>
            (Base, _height) = (rectangle, height);

        /// <summary>
        /// Get volume of block.
        /// </summary>
        /// <returns> Volume of block </returns>
        public double GetVolume() =>
             _height * Base.Area;

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public void EventHandler(object sender, SideHasChangedEventArgs e)
        {
            // Change height.
            _height /= e.Coefficient;

            Console.WriteLine($"\nNew value of area: {e.OldArea * e.Coefficient:0.###}");
            Console.WriteLine($"\nNew value of height: {_height:0.###}");
        }
    }
}
