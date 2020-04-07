using System;
using System.Collections.Generic;

namespace MyLib
{
    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }
    }
}