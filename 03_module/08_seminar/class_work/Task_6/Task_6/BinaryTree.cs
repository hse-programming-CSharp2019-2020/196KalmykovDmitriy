using System;

namespace Task_6
{
    internal class BinaryTree<TItem>
     where TItem : IComparable<TItem>
    {
        internal bool Empty => MainNode == null;

        // Tree root.
        internal BtNode<TItem> MainNode { get; private set; }

        // Constructor.
        internal BinaryTree() =>
            MainNode = null;

        /// <summary>
        /// Insert item to the tree.
        /// </summary>
        /// <param name="item"> Item </param>
        public void Insert(TItem item)
        {
            // Add value or node.
            if (MainNode == null)
            {
                MainNode = new BtNode<TItem>(item);
            }
            else
            {
                MainNode.Insert_value(item);
            }
        }

        /// <summary>
        /// Find element in tree.
        /// </summary>
        /// <param name="val"> Value for searching </param>
        /// <returns> True ot false </returns>
        public bool Find(TItem val) =>
            MainNode != null && MainNode.Find(val);

        /// <summary>
        /// Clear all tree.
        /// </summary>
        internal void Clear() =>
            MainNode = null;

        /// <summary>
        /// Print tree in preorder.
        /// </summary>
        /// <param name="node"> Start node</param>
        internal void Preorder(BtNode<TItem> node)
        {
            while (true)
            {
                if (node is null)
                {
                    return;
                }

                Program.PrintMessage(node.Val + " ", ConsoleColor.Yellow);

                if (node.LChild != null)
                {
                    Preorder(node.LChild);
                }

                if (node.RChild != null)
                {
                    node = node.RChild;
                    continue;
                }

                break;
            }
        }

        /// <summary>
        /// Print tree in inorder.
        /// </summary>
        /// <param name="node"> Start node </param>
        internal void Inorder(BtNode<TItem> node)
        {
            while (true)
            {
                if (node == null) return;

                Inorder(node.LChild);

                Program.PrintMessage(node.Val + " ", ConsoleColor.Yellow);

                node = node.RChild;
            }

        }

        /// <summary>
        /// Print tree in postorder.
        /// </summary>
        /// <param name="node"> Start node </param>
        internal void Postorder(BtNode<TItem> node)
        {
            if (node is null)
                return;

            Postorder(node.LChild);

            Postorder(node.RChild);

            Program.PrintMessage(node.Val + " ", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Remove tree item.
        /// </summary>
        /// <param name="val"> Value to delete </param>
        internal void Delete(TItem val)
        {
            if (val.Equals(MainNode.Val))
            {
                MainNode = null;
                return;
            }

            MainNode.Delete(val);
        }
    }
}
