using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace Task_1
{
    internal class Program
    {
        /// <summary>
        /// Digits.
        /// </summary>
        private static readonly char[] Digits =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        /// <summary>
        /// Invalid symbols.
        /// </summary>
        private static readonly char[] InvalidSymbols =
        {
            '!', '\"', '#', '№', '$', ';', '%',
            '^', ':', '&', '?', '*', '(', ')',' ',
            '-', '+', '=', '[', '{', ']', '}',
            '|', '\\', '/', '\'', '<', ',', '>', '.'
        };

        /// <summary>
        /// Keywords.
        /// </summary>
        private static readonly string[] Keywords =
        {
            "abstract" , "as",    "base" , "bool",
            "break" ,"byte" ,"case",    "catch" ,
            "char"  ,  "checked", "class" ,  "const",
            "continue", "decimal" ,"default" ,"delegate",
            "do",   "double",   "else"  ,"enum",
           " event",   "explicit",    "extern", "false",
            "finally",  "fixed", "float",   "for",
            "foreach",  "goto", "if",   "implicit",
            "in", "int", "interface",   "internal",
            "is",   "lock", "long",    "namespace",
            "new",   "null",    "object", "operator",
            "out",  "override", "params", "private",
            "protected", "public", "readonly", "ref",
            "return",   "sbyte", "sealed", "short",
            "sizeof",   "stackalloc",   "static", "string",
            "struct",  "switch",    "this",    "throw",
            "true", "try",  "typeof",   "uint",
            "ulong",   "unchecked", "unsafe", "ushort",
            "using",    "using", "static",  "virtual", "void",
            "volatile", "while",

            "add", "alias",   "ascending",
            "async",   "await",   "by",
            "descending",  "dynamic", "equals",
            "from",    "get", "global",
            "group", "into",   "join",
            "let", "nameof",  "on",
            "OrderBy", "partial",
            "remove",  "select" ,  "set",
            "unmanaged ","value",   "var",
            "when", "where", "yield"
        };

        /// <summary>
        /// Processing line from file.
        /// </summary>
        /// <param name="line"> some text </param>
        /// <returns> List of identifiers </returns>
        private static IEnumerable<StringBuilder> Processing(string line)
        {
            var result = new List<StringBuilder>();
            var curIdentifier = new StringBuilder();

            for (var i = 0; i < line.Length; i++)
            {
                // Last step.
                if (i == line.Length - 1)
                {
                    if (InvalidSymbols.Any(el => el == line[i]))
                    {
                        if (curIdentifier.Length > 0)
                        {
                            result.Add(curIdentifier);
                        }

                        result = TrimDigits(result);
                        result = CheckForDogLetter(result);
                        result = CheckForKeywords(result);

                        return result;
                    }
                    else
                    {
                        curIdentifier.Append(line[i]);
                        result.Add(curIdentifier);

                        result = TrimDigits(result);
                        result = CheckForDogLetter(result);
                        result = CheckForKeywords(result);

                        return result;
                    }
                }

                // Split string by invalid symbols.
                if (InvalidSymbols.Any(el => el == line[i]))
                {
                    if (curIdentifier.Length > 0)
                    {
                        var temp = new StringBuilder((string)curIdentifier.ToString().Clone());
                        result.Add(temp);
                    }

                    curIdentifier.Clear();

                    continue;
                }

                curIdentifier.Append(line[i]);
            }

            result = TrimDigits(result);
            result = CheckForDogLetter(result);
            result = CheckForKeywords(result);

            return result;
        }

        /// <summary>
        /// Check identifiers for keywords.
        /// </summary>
        /// <param name="varNames"> List of variable's names </param>
        /// <returns> Suitable var names </returns>
        private static List<StringBuilder> CheckForKeywords(List<StringBuilder> varNames)
        {
            varNames = (from name in varNames
                        where !Keywords.Contains(name.ToString())
                        select name).ToList();

            return varNames;
        }

        /// <summary>
        /// Check line for availability dog letter.
        /// </summary>
        /// <param name="varNames"> List of variable's name </param>
        /// <returns> List of suitable identifiers </returns>
        private static List<StringBuilder> CheckForDogLetter(List<StringBuilder> varNames)
        {
            var identifiersWithDogLetter = new List<StringBuilder>();

            for (var i = 0; i < varNames.Count; i++)
            {
                for (var j = 1; j < varNames[i].Length; j++)
                {
                    if (!(varNames[i][j] is '@'))
                    {
                        continue;
                    }

                    identifiersWithDogLetter.Add(varNames[i]);
                    varNames.RemoveAt(i);
                    break;
                }
            }

            // Remove name such as just one '@'.
            varNames = (from name in varNames
                        where name.Length > 1 || char.IsLetter(name[0])
                        select name).ToList();

            var correctIdentifiersList = new List<string>();

            foreach (StringBuilder identifier in identifiersWithDogLetter)
            {
                string[] correctIdentifiersArray = identifier.ToString().Split(
                    new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                // Special processing first name.
                if (identifier[0] is '@')
                {
                    correctIdentifiersList.Add('@' + correctIdentifiersArray[0]);
                }
                else
                {
                    correctIdentifiersList.Add(correctIdentifiersArray[0]);
                }

                // Processing other name.
                for (var i = 1; i < correctIdentifiersArray.Length; i++)
                {
                    correctIdentifiersArray[i] = '@' + correctIdentifiersArray[i];
                    correctIdentifiersList.Add(correctIdentifiersArray[i]);
                }
            }

            List<StringBuilder> resultList =
                correctIdentifiersList.Select(el => new StringBuilder(el)).ToList();

            resultList = TrimDigits(resultList);

            varNames.AddRange(resultList);

            return varNames;
        }

        /// <summary>
        /// Check line for empty.
        /// </summary>
        /// <param name="varName"> Variable's name </param>
        /// <returns> True of false </returns>
        private static bool IsEmpty(StringBuilder varName)
        {
            return varName.ToString().TrimStart(Digits).Length == 0;
        }

        /// <summary>
        /// Trim start digits.
        /// </summary>
        /// <param name="varNames"> List of variable's names </param>
        /// <returns> Modified list </returns>
        private static List<StringBuilder> TrimDigits(List<StringBuilder> varNames)
        {
            varNames = (from name in varNames
                        where (!IsEmpty(name))
                        select new StringBuilder(name.ToString().TrimStart(Digits))).ToList();

            return varNames;
        }

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var pathForReading = $@"..{sep}..{sep}..{sep}Data.txt";
            var pathForWriting = $@"..{sep}..{sep}..{sep}VarNames.txt";
            var result = new List<StringBuilder>();

            // Check file for existence.
            try
            {
                if (!File.Exists(pathForReading))
                {
                    using (File.Create(pathForReading)) ;
                }

                // Read text from file.
                using (var sr = File.OpenText(pathForReading))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        result.AddRange(Processing(line));
                    }
                }

                // Transform List<StringBuilder> -> List<string>.
                var resultNames = new List<string>(result.Select(name => name.ToString()));

                // Sorting identifiers.
                resultNames.Sort();

                // Write text to file.
                using (var sw = new StreamWriter(pathForWriting, false, Encoding.UTF8))
                {
                    foreach (string name in resultNames)
                    {
                        sw.WriteLine(name);
                    }
                }
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!\n\n", ConsoleColor.Red);
            }
            catch (SecurityException)
            {
                PrintMessage("Access error!\n\n", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!\n\n", ConsoleColor.Red);
            }

            PrintMessage("Press ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
