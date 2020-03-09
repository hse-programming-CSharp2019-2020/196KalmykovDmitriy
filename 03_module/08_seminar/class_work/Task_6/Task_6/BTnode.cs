using System;

namespace Task_6
{
    internal class BtNode<TVal>
    where TVal : IComparable<TVal>
    {
        internal TVal Val;
        internal int Count { get; private set; }

        // Left child of node.
        internal BtNode<TVal> LChild; 
        
        // Right child of node.
        internal BtNode<TVal> RChild;

        // Constructor.
        internal BtNode(TVal val) =>
            (Val, Count, LChild, RChild) = (val, 1, null, null);

        /// <summary>
        /// Find element in tree.
        /// </summary>
        /// <param name="val"> Value for searching </param>
        /// <returns> True or false </returns>
        internal bool Find(TVal val) =>
            val.Equals(Val) || (val.CompareTo(Val) < 0
                ? LChild != null && LChild.Find(val)
                : RChild != null && RChild.Find(val));

        /// <summary>
        /// Delete element of tree.
        /// </summary>
        /// <param name="val"> Value of element </param>
        internal void Delete(TVal val)
        {
            if (LChild != null && LChild.Val.Equals(val))
            {
                    LChild = null;
                    return;
            }

            if (RChild != null && RChild.Val.Equals(val))
            {
                    RChild = null;
                    return;
            }

            if (val.CompareTo(Val) < 0)
            {
                if (LChild == null)
                    throw new Exception("such an element does not exist!");
                
                LChild.Delete(val);
            }
            else
            {
                if (RChild == null)
                    throw new Exception("such an element does not exist");
                
                RChild.Delete(val);
            }
        }

        /// <summary>
        /// Insert element to tre tree.
        /// </summary>
        /// <param name="val"></param>
        internal void Insert_value(TVal val)
        {
            if (val.Equals(Val))
            {
                Count++; return;
            }

            if (val.CompareTo(Val) < 0)
            {
                if (LChild == null) LChild = new BtNode<TVal>(val);
                else LChild.Insert_value(val);
            }
            else
            {
                if (RChild == null) RChild = new BtNode<TVal>(val);
                else RChild.Insert_value(val);
            }
        }
    }
}
