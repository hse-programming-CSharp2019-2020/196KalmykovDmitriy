namespace Task_2
{
    internal class Cylinder : ITransform
    {
        // Radius of base circle.
        private double R { get; set; } = 1;

        // Height of cylinder.
        private double H { get; set; } = 1;

        /// <summary>
        /// Change radius of base and height of cylinder.
        /// </summary>
        /// <param name="coefficient"> Coefficient </param>
        public void Transform(double coefficient) =>
            (R, H) = (R * coefficient, H * coefficient);

        /// <summary>
        /// Method for return info about cylinder.
        /// </summary>
        /// <returns> Info about cylinder </returns>
        public override string ToString() =>
            $"Radius of base: {R:0.####}, Height: {H:0.####}";
    }
}
