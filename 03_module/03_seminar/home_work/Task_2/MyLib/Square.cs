using System;

namespace MyLib
{
    // Declare delegate.
    public delegate void SquareSizeChanged(double el);

    /// <summary>
    /// Class Square.
    /// </summary>
    public class Square
    {
        // Corners.
        private (double, double) _leftUpperCorner;
        private (double, double) _rightDownCorner;

        // Event.
        public event SquareSizeChanged OnSizeChanged;

        // Constructor.
        public Square((double, double) luCorn, (double, double) rdCorn) =>
            (LeftUpperCorner, RightDownCorner) = (luCorn, rdCorn);

        // Property for left upper corner.
        public (double x, double y) LeftUpperCorner
        {
            get => _leftUpperCorner;
            set
            {
                // Raise event.
                OnSizeChanged?.Invoke((-RightDownCorner.x + LeftUpperCorner.x) + value.x);
                _leftUpperCorner = value;
            }
        }

        // Property for right down corner.
        public (double x, double y) RightDownCorner
        {
            get => _rightDownCorner;
            set
            {
                CheckForSquare(value);

                // Raise event.
                OnSizeChanged?.Invoke((-RightDownCorner.x + LeftUpperCorner.x) + value.x);
                _rightDownCorner = value;
            }
        }

        /// <summary>
        /// Check for square.
        /// </summary>
        /// <param name="rightDownCorner"> Right down corner </param>
        private void CheckForSquare((double x, double y) rightDownCorner)
        {
            var (x, y) = rightDownCorner;

            // Check for correct coordinates of corner.
            if ((x <= LeftUpperCorner.x) || (y >= LeftUpperCorner.y))
                throw new IndexOutOfRangeException("The lower right corner must be lower" +
                    " and to the right of the left upper corner");

            // Check for form.
            if (Math.Abs((Math.Abs(x - LeftUpperCorner.x)
                           - Math.Abs(y - LeftUpperCorner.y))) > double.Epsilon)
                throw new IndexOutOfRangeException("This is a rectangle and not a square");
        }
    }
}
