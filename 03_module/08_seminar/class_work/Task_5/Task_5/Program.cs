using System;

namespace Task_5
{
    internal class Program
    {
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

        /// <summary>
        /// Get 2 stack.
        /// </summary>
        /// <returns> Stacks </returns>
        private static (MyStack<int>, MyStack<string>) GetStacks()
        {
            var stackInt = new MyStack<int>();
            var stackString = new MyStack<string>();

            return (stackInt, stackString);
        }

        /// <summary>
        /// Test 2 stack.
        /// </summary>
        /// <param name="stackInt"> Stack of integer number </param>
        /// <param name="stackString"> Stack of string </param>
        private static void TestStacks(MyStack<int> stackInt, MyStack<string> stackString)
        {
            stackInt.Push(3);
            stackInt.Push(5);
            stackInt.Push(7);
            Console.WriteLine(stackInt);

            stackString.Push("Generics are great!");
            stackString.Push("Hi there! ");
            Console.WriteLine(stackString);
        }

        /// <summary>
        /// Get 2 queue.
        /// </summary>
        /// <returns> Queues </returns>
        private static (MyQueue<int>, MyQueue<string>) GetQueues()
        {
            var queueInt = new MyQueue<int>();
            var queueString = new MyQueue<string>();

            return (queueInt, queueString);
        }

        /// <summary>
        /// Get 2 queues.
        /// </summary>
        /// <param name="queueInt"> Queue of integer number </param>
        /// <param name="queueString"> Queue of string </param>
        private static void TestQueues(MyQueue<int> queueInt, MyQueue<string> queueString)
        {
            queueInt.Enqueue(7);
            queueInt.Enqueue(5);
            queueInt.Enqueue(3);
            Console.WriteLine(queueInt);

            queueString.Enqueue("Hi there again!");
            queueString.Enqueue("Generics are really great!");
            Console.WriteLine(queueString);
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                var (stackInt, stackString) = GetStacks();
                var (queueInt, queueString) = GetQueues();

                TestStacks(stackInt, stackString);

                TestQueues(queueInt, queueString);

                PrintMessage("Press ESC to exit, press any other ley to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
