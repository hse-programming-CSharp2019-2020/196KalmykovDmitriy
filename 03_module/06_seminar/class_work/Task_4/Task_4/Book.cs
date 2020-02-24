using System;
using System.Text;

namespace Task_4
{
    internal class Book : IBook
    {
        public string Title { set; get; }

        public string Author { set; get; }

        public int Pages { set; get; }

        public string Publisher { set; get; }

        public int Year { set; get; }

        // Content of book.
        public StringBuilder Content { get; set; } = new StringBuilder(string.Empty);

        /// <summary>
        /// Rewrite publication.
        /// </summary>
        /// <param name="text"> New text </param>
        public void Write(StringBuilder text) =>
            Content = text;

        /// <summary>
        /// Read content of book.
        /// </summary>
        public void Read()
        {
            if (string.IsNullOrEmpty(Content.ToString()))
                Console.WriteLine("Book hasn't content");
            else
            {
                Console.WriteLine("Content of book: ");
                Console.WriteLine(Content);
            }
        }

        /// <summary>
        /// Append text to existing.
        /// </summary>
        /// <param name="text"> Text for addition </param>
        public void Append(StringBuilder text) =>
            Content.Append(Environment.NewLine + text);

        /// <summary>
        /// Return info about book.
        /// </summary>
        /// <returns> Info about book </returns>
        public override string ToString() =>
            $"Author: {Author}, Title: {Title}";
    }
}
