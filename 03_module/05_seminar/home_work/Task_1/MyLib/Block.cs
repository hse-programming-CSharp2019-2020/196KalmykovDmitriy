using System;

namespace MyLib
{
    /// <summary>
    /// Class Block.
    /// </summary>
    public class Block
    {
        // Event.
        public event EventHandler SideHasChangedEvent;

        private double _height;
        private readonly double _volumeBeforeChange;

        /// <summary>
        /// Change side and raise event.
        /// </summary>
        /// <param name="side1"> new Side 1 </param>
        /// <param name="side2"> new Side 2 </param>
        public void ChangeSide(double side1, double side2)
        {
            (Base.Side1, Base.Side2) = (side1, side2);

            SideHasChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        // Base of block.
        private Rectangle Base { get; }

        // Constructor.
        public Block(Rectangle rectangle, double height)
        {
            (Base, _height) = (rectangle, height);

            _volumeBeforeChange = GetVolume();
        }

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
        /// <param name="args"> Args </param>
        public void EventHandler(object sender, EventArgs args)
        {
            // Change height.
            _height = _volumeBeforeChange / Base.Area;

            Console.WriteLine($"\nNew value of height: {_height:0.###}");
        }
    }
}
