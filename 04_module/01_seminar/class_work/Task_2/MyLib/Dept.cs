using System;
using System.Collections.Generic;

namespace MyLib
{
    [Serializable]
    public class Dept
    {
        public string DeptName { get; set; }
        public List<Human> Staff { get; set; }

        public Dept() { }

        // Constructor.
        public Dept(string name, IEnumerable<Human> staffList)
        {
            DeptName = name;
            Staff = new List<Human>(staffList);
        }
    }

}