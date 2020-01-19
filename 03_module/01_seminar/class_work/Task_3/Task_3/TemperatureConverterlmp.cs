namespace Task_3
{
    /// <summary>
    /// Class for conversion.
    /// </summary>
    internal class TemperatureConverterlmp
    {
        /// <summary>
        /// Conversion from Fahrenheit to Celsius degree.
        /// </summary>
        /// <param name="fahrenheitDegrees"> Fahrenheit degrees </param>
        /// <returns> Celsius degrees </returns>
        internal double ConvertFahrenheitToCelsius(double fahrenheitDegrees) =>
            5.0 / 9 * (fahrenheitDegrees - 32);

        /// <summary>
        /// Conversion from Celsius to Fahrenheit degree.
        /// </summary>
        /// <param name="celsiusDegrees"> Celsius degrees </param>
        /// <returns> Fahrenheit degrees </returns>
        internal double ConvertCelsiusToFahrenheit(double celsiusDegrees) =>
            9.0 / 5 * celsiusDegrees + 32;
    }
}
