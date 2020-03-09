using System;

namespace Task_6
{
    internal class Program
    {
        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        internal static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Get 2 type of trees.
        /// </summary>
        /// <returns> 2 trees </returns>
        private static (BinaryTree<string>, BinaryTree<int>) GetTrees()
        {
            var binaryTreeString = new BinaryTree<string>();
            var binaryTreeInt = new BinaryTree<int>();

            return (binaryTreeString, binaryTreeInt);
        }

        /// <summary>
        /// Fill 2 trees.
        /// </summary>
        /// <param name="binaryTreeString"> First trees </param>
        /// <param name="binaryTreeInt"> Second trees </param>
        private static void FillTrees(ref BinaryTree<string> binaryTreeString,
            ref BinaryTree<int> binaryTreeInt)
        {
            #region Fill binary tree string.

            binaryTreeString.Insert("Me");
            binaryTreeString.Insert("Mom");
            binaryTreeString.Insert("Dad");
            binaryTreeString.Insert("Dad\'s dad");
            binaryTreeString.Insert("Mom\'s mom");
            binaryTreeString.Insert("Dad\'s mom");
            binaryTreeString.Insert("Mom\'s dad");
            binaryTreeString.Insert("Mom\'s dgrvfdcsxad");
            binaryTreeString.Insert("Mom\'s dad123123");
            

            #endregion

            #region Fill binary tree int.

            binaryTreeInt.Insert(-4);
            binaryTreeInt.Insert(9);
            binaryTreeInt.Insert(3);
            binaryTreeInt.Insert(7);
            binaryTreeInt.Insert(-42);
            binaryTreeInt.Insert(349);
            binaryTreeInt.Insert(92);
            binaryTreeInt.Insert(19);
            binaryTreeInt.Insert(9);

            #endregion
        }

        /// <summary>
        /// Print binary trees.
        /// </summary>
        /// <param name="binaryTreeString"> Binary tree of strings </param>
        /// <param name="binaryTreeInt"> Binary tree of numbers </param>
        private static void PrintTrees(BinaryTree<string> binaryTreeString,
            BinaryTree<int> binaryTreeInt)
        {
            PrintMessage("1) Test methods for print trees:\n\n", ConsoleColor.Green);

            #region Print binary tree string.

            PrintMessage("Binary tree (string):\n", ConsoleColor.Magenta);

            PrintMessage("\nPreorder: ");
            binaryTreeString.Preorder(binaryTreeString.MainNode);
            Console.WriteLine();

            PrintMessage("\nInorder: ");
            binaryTreeString.Inorder(binaryTreeString.MainNode);
            Console.WriteLine();

            PrintMessage("\nPostorder: ");
            binaryTreeString.Postorder(binaryTreeString.MainNode);
            Console.WriteLine();

            #endregion

            Console.WriteLine();

            #region Print binary tree int.

            PrintMessage("Binary tree (int):\n", ConsoleColor.Magenta);

            PrintMessage("\nPreorder: ");
            binaryTreeInt.Preorder(binaryTreeInt.MainNode);
            Console.WriteLine();

            PrintMessage("\nInorder: ");
            binaryTreeInt.Inorder(binaryTreeInt.MainNode);
            Console.WriteLine();

            PrintMessage("\nPostorder: ");
            binaryTreeInt.Postorder(binaryTreeInt.MainNode);
            Console.WriteLine();

            #endregion
        }

        /// <summary>
        /// Delete some elements from each trees.
        /// </summary>
        /// <param name="binaryTreeString"> First tree </param>
        /// <param name="binaryTreeInt"> Second tree </param>
        private static void DeleteElementsOfTrees(BinaryTree<string> binaryTreeString,
            BinaryTree<int> binaryTreeInt)
        {
            PrintMessage("\n2) Test method Delete():", ConsoleColor.Green);

            #region Binary tree string.

            PrintMessage("\n\nBinary tree (string):", ConsoleColor.Magenta);

            PrintMessage("\n\nBefore deleting: ");
            binaryTreeString.Inorder(binaryTreeString.MainNode);

            binaryTreeString.Delete("Mom\'s dad");
            PrintMessage("\n\nAfter deleting element \"Mom\'s dad\" and his descendants: ");
            binaryTreeString.Inorder(binaryTreeString.MainNode);

            #endregion

            #region Binary tree int.

            PrintMessage("\n\nBinary tree (int):", ConsoleColor.Magenta);

            PrintMessage("\n\nBefore deleting: ");
            binaryTreeInt.Inorder(binaryTreeInt.MainNode);

            binaryTreeInt.Delete(9);
            PrintMessage("\n\nAfter deleting element 9 and his descendants: ");
            binaryTreeInt.Inorder(binaryTreeInt.MainNode);

            #endregion

            Console.WriteLine();
        }

        /// <summary>
        /// Find some elements in trees.
        /// </summary>
        /// <param name="binaryTreeString"> First tree </param>
        /// <param name="binaryTreeInt"> Second tree </param>
        private static void FindElementsInTrees(BinaryTree<string> binaryTreeString,
            BinaryTree<int> binaryTreeInt)
        {
            PrintMessage("\n3) Test method Find():", ConsoleColor.Green);

            #region Binary tree string.

            PrintMessage("\n\nBinary tree (string):\n\n", ConsoleColor.Magenta);

            PrintMessage("The tree contain main node: ");
            PrintMessage(binaryTreeString.Find(binaryTreeString.MainNode.Val).ToString(),
                ConsoleColor.Yellow);

            PrintMessage("\nThe tree contain element \"Mom\": ");
            PrintMessage(binaryTreeString.Find("Mom").ToString(),
                ConsoleColor.Yellow);

            PrintMessage("\nThe tree contain element \"Hell to world\": ");
            PrintMessage(binaryTreeString.Find("Hell to world").ToString(),
                ConsoleColor.Yellow);

            PrintMessage("\nThe tree contain element \"Mom\'s dad\": ");
            PrintMessage(binaryTreeString.Find("Mom\'s dad").ToString(),
                ConsoleColor.Yellow);

            #endregion

            #region Binary tree int.

            PrintMessage("\n\nBinary tree (int):\n\n", ConsoleColor.Magenta);

            PrintMessage("The tree contain main node: ");
            PrintMessage(binaryTreeInt.Find(binaryTreeInt.MainNode.Val).ToString(),
                ConsoleColor.Yellow);

            PrintMessage("\nThe tree contain element -4: ");
            PrintMessage(binaryTreeInt.Find(-4).ToString(),
                ConsoleColor.Yellow);

            PrintMessage("\nThe tree contain element -5: ");
            PrintMessage(binaryTreeInt.Find(-5).ToString(),
                ConsoleColor.Yellow);

            PrintMessage("\nThe tree contain element 19: ");
            PrintMessage(binaryTreeInt.Find(19).ToString(),
                ConsoleColor.Yellow);

            #endregion

            Console.WriteLine();
        }

        /// <summary>
        /// Clear all trees.
        /// </summary>
        /// <param name="binaryTreeString"> First tree </param>
        /// <param name="binaryTreeInt"> Second tree </param>
        private static void ClearTrees(BinaryTree<string> binaryTreeString,
            BinaryTree<int> binaryTreeInt)
        {
            PrintMessage("\n4) Test method Clear():", ConsoleColor.Green);

            #region Binary tree string.

            PrintMessage("\n\nBinary tree (string):\n\n", ConsoleColor.Magenta);

            PrintMessage("Clear all tree: ");
            binaryTreeString.Clear();

            if (binaryTreeString.MainNode is null)
            {
                PrintMessage("Tree is null!", ConsoleColor.Red);
            }

            #endregion

            #region Binary tree int.

            PrintMessage("\n\nBinary tree (int):\n\n", ConsoleColor.Magenta);

            PrintMessage("Clear all tree: ");
            binaryTreeInt.Clear();

            if (binaryTreeInt.MainNode is null)
            {
                PrintMessage("Tree is null!\n", ConsoleColor.Red);
            }

            #endregion
        }

        private static void Main()
        {
            var (binaryTreeString, binaryTreeInt) = GetTrees();

            FillTrees(ref binaryTreeString, ref binaryTreeInt);

            PrintTrees(binaryTreeString, binaryTreeInt);

            DeleteElementsOfTrees(binaryTreeString, binaryTreeInt);

            FindElementsInTrees(binaryTreeString, binaryTreeInt);

            ClearTrees(binaryTreeString, binaryTreeInt);

            PrintMessage("\nPress ESC to exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
