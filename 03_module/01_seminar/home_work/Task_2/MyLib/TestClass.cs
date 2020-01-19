namespace MyLib
{
    // Declare delegate.
    public delegate int MeDel(double val1, double val2);

    /// <summary>
    /// Class for test.
    /// </summary>
    public class TestClass
    {
        // Как вариант можно было считать это через Math.Truncate, т.к.
        // Math.Truncate(x) == (int)x.
        /// <summary>
        /// Get sum of integer parts of 2 numbers.
        /// </summary>
        /// <param name="val1"> First number </param>
        /// <param name="val2"> Second number </param>
        /// <returns> sum of integer parts of 2 numbers </returns>
        public int TestMethod(double val1, double val2) =>
            (int)val1 + (int)val2;
    }
}
