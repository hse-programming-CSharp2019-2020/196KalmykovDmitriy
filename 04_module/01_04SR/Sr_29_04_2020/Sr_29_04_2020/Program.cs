using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sr_29_04_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, -2, 3, 4};

            IEnumerable<int> query = from n in nums
                        where n >= 0
                        select n;

            foreach (var i in query)
            {
                
            }
        }
    }
}
