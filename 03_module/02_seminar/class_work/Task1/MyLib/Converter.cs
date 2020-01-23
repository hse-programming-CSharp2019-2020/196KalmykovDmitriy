using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{

    public delegate string ConvertRule(string str);

    public class Converter
    {
        public string Convert(string str, ConvertRule cr) => cr(str);
    }
}
