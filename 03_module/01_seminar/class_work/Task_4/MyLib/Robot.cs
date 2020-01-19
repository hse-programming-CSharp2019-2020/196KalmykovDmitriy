namespace MyLib
{
    // Declare delegat.
    public delegate void Steps();

    /// <summary>
    /// Class robot.
    /// </summary>
    public class Robot
    {
        // Coordinates.
        private int x, y;

        // Properties for x, y.
        public int X => x;
        public int Y => y;

        /// <summary>
        /// Go right.
        /// </summary>
        public void Right() => x++;

        /// <summary>
        /// Go left.
        /// </summary>
        public void Left() => x--;

        /// <summary>
        /// Go forward.
        /// </summary>
        public void Forward() => y++;

        /// <summary>
        /// Go backward.
        /// </summary>
        public void Backward() => y--;

        /// <summary>
        /// Position of robot.
        /// </summary>
        /// <returns> Position of robot </returns>
        public string Position() =>
            $"The Robot position: x={x}, y={y}";
    }
}
