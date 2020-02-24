using System.Text;

namespace Task_4
{
    internal interface IPublication
    {
        /// <summary>
        /// Write publication.
        /// </summary>
        /// <param name="text"> Text of publication </param>
        void Write(StringBuilder text);

        /// <summary>
        /// Read publication.
        /// </summary>
        void Read();

        /// <summary>
        /// Append text to book.
        /// </summary>
        /// <param name="text"> Content </param>
        void Append(StringBuilder text);

        string Title { set; get; }
    }
}
