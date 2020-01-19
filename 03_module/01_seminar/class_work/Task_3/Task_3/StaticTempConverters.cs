namespace Task_3
{
    /// <summary>
    /// Static class for conversion.
    /// </summary>
    internal class StaticTempConverters
    {
        /// <summary>
        /// Conversion from Celsius to Kelvin degree.
        /// </summary>
        /// <param name="celsiusDegrees"> Celsius degrees </param>
        /// <returns> Kelvin degrees </returns>
        internal static double ConvertCelsiusToKelvin(double celsiusDegrees) =>
            celsiusDegrees + 273.15;

        /// <summary>
        /// Conversion from Celsius to Rankin degree.
        /// </summary>
        /// <param name="celsiusDegrees"> Celsius degrees </param>
        /// <returns> Rankin degrees </returns>
        internal static double ConvertCelsiusToRankin(double celsiusDegrees) =>
            (celsiusDegrees + 273.15) * 9.0 / 5;

        /// <summary>
        /// Conversion from Celsius to Reaumur degree.
        /// </summary>
        /// <param name="celsiusDegrees"> Celsius degrees </param>
        /// <returns> Raumur degrees </returns>
        internal static double ConvertCelsiusToReaumur(double celsiusDegrees) =>
            celsiusDegrees * 4.0 / 5;

        /// <summary>
        /// Conversion from Kelvin to Celsius degree.
        /// </summary>
        /// <param name="kelvinDegrees"> Kelvin degrees </param>
        /// <returns> Celsius degrees </returns>
        internal static double ConvertKelvinToCelsius(double kelvinDegrees) =>
            kelvinDegrees - 273.15;

        /// <summary>
        /// Conversion from Rankin to Celsius degree.
        /// </summary>
        /// <param name="rankinDegrees"> Rankin degrees </param>
        /// <returns> Celsius degrees </returns>
        internal static double ConvertRankinToCelsius(double rankinDegrees) =>
            (rankinDegrees - 491.67) * 5.0 / 9;

        /// <summary>
        /// Conversion from Reaumur to Celsius degree.
        /// </summary>
        /// <param name="reaumurDegrees"> Reaumur degrees </param>
        /// <returns> Celsius degrees </returns>
        internal static double ConvertReaumurToCelsius(double reaumurDegrees) =>
            reaumurDegrees * 5.0 / 4;
    }
}
