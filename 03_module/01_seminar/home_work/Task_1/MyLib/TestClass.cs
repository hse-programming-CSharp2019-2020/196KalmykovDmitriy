using System;

namespace MyLib
{
    // Declare delegate.
    public delegate int MyDel(int val1, int val2);

    /// <summary>
    /// Class for test.
    /// </summary>
    public static class TestClass
    {
        /// <summary>
        /// Find max number.
        /// </summary>
        /// <param name="val1"> First number </param>
        /// <param name="val2"> Second number </param>
        /// <returns> Max number </returns>
        public static int TestMethod(int val1, int val2) =>
            Math.Max(val1, val2);
    }
}