namespace Task_4
{
    /// <summary>
    /// Class UIString.
    /// </summary>
    internal class UIString
    {
        // Property for string.
        internal string Str { get; set; } = "Default text";

        /// <summary>
        /// Set value in property.
        /// </summary>
        /// <param name="s"> String </param>
        internal void NewStringValueHappenedHandler(string s)=>
            Str = s;
    }
}
