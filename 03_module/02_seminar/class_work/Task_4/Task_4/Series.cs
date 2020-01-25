using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Series
    {
        internal int[] arrInts;

        internal void Order(Comparison<int> cond)=>
            Array.Sort(arrInts, cond);
    }
}
