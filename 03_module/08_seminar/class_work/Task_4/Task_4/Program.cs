using System;

namespace Task_4
{
    internal class Program
    {
        /// <summary>
        /// Get different stacks.
        /// </summary>
        /// <returns> Three type of stacks </returns>
        private static (Stack<char>, Stack<double>, Stack<Point>) GetStacks()
        {
            var charStack = new Stack<char>();
            var doubleStack = new Stack<double>();
            var pointStack = new Stack<Point>();

            return (charStack, doubleStack, pointStack);
        }

        /// <summary>
        /// Get different queues.
        /// </summary>
        /// <returns> Three type of queues </returns>
        private static (Queue<char>, Queue<double>, Queue<Point>) GetQueues()
        {
            var charQueue = new Queue<char>();
            var doubleQueue = new Queue<double>();
            var pointQueue = new Queue<Point>();

            return (charQueue, doubleQueue, pointQueue);
        }

        /// <summary>
        /// Test stacks.
        /// </summary>
        /// <param name="charStack"> Stack of letters </param>
        /// <param name="doubleStack"> Stack of real numbers </param>
        /// <param name="pointStack"> Stack of points </param>
        private static void TestStacks(Stack<char> charStack,
            Stack<double> doubleStack, Stack<Point> pointStack)
        {
            // Test char stack.
            charStack.Push('A');
            charStack.Push('B');
            PrintMessage($"charStack.Pop() = {charStack.Pop()}\n");

            // Test double stack.
            doubleStack.Push(3.14159);
            doubleStack.Push(6.28318);
            var x = doubleStack.Pop();
            PrintMessage($"x = {x}\n");

            // Test point stack.
            pointStack.Push(new Point());
            var p = pointStack.Pop();
            PrintMessage($"p.X = {p.X}, p.Y = {p.Y}\n");
        }

        /// <summary>
        /// Test queues.
        /// </summary>
        /// <param name="charQueue"> Queue of letters </param>
        /// <param name="doubleQueue"> Queue of real numbers </param>
        /// <param name="pointQueue"> Queue of points </param>
        private static void TestQueues(Queue<char> charQueue,
            Queue<double> doubleQueue, Queue<Point> pointQueue)
        {
            // Test char queue.
            charQueue.Enqueue('A');
            charQueue.Enqueue('B');
            PrintMessage($"charQueue.Dequeue() = {charQueue.Dequeue()}\n" +
                         $"First element of queue: {charQueue.First}\n");

            // Test double queue.
            doubleQueue.Enqueue(3.14159);
            doubleQueue.Enqueue(6.28318);
            var x = doubleQueue.Dequeue();
            PrintMessage($"x = {x}\n");

            // Test point queue.
            pointQueue.Enqueue(new Point());
            var p = pointQueue.Dequeue();
            PrintMessage($"p.X = {p.X}, p.Y = {p.Y}\n");
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
            do
            {
                Console.Clear();

                var (charStack, doubleStack, pointStack) = GetStacks();
                var (charQueue, doubleQueue, pointQueue) = GetQueues();

                TestStacks(charStack, doubleStack, pointStack);

                Console.WriteLine();

                TestQueues(charQueue, doubleQueue, pointQueue);

                PrintMessage("\nPress ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
