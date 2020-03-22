using System;
using System.IO;
using System.Security;

namespace Task_5
{
    internal class MyLog : IDisposable
    {
        private readonly char _sep = Path.DirectorySeparatorChar;

        private readonly StreamWriter _sw;

        // Constructor.
        public MyLog()
        {
            var logPath = $@"..{_sep}..{_sep}..{_sep}Logger.txt";
            try
            {
                File.WriteAllText(logPath, string.Empty);
                _sw = File.AppendText(logPath);
            }
            catch (IOException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (Exception)
            {
            }

            WriteToLog($"Log started at {DateTime.Now}\n");
        }

        /// <summary>
        /// Print info to file.
        /// </summary>
        /// <param name="messageString"> Message </param>
        public void WriteToLog(string messageString)
        {
            try
            {
                _sw.WriteLine(messageString);
            }
            catch (IOException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
        }

        /// <summary>
        /// Implementation IDisposable.
        /// </summary>
        public void Dispose()
        {
            try
            {
                _sw.WriteLine($"\nLog finished at {DateTime.Now}");
                _sw.Dispose();
            }
            catch (IOException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
        }
    }
}
