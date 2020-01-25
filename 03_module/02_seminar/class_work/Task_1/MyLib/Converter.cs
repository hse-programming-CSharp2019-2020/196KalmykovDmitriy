namespace MyLib
{
    // Declare delegate.
    public delegate string ConvertRule(string str);

    /// <summary>
    /// Class converter.
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Convert string.
        /// </summary>
        /// <param name="str"> String for change </param>
        /// <param name="cr"> Rule of change </param>
        /// <returns> Transformed string </returns>
        public string Convert(string str, ConvertRule cr) => cr(str);
    }
}