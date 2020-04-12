using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Task_6
{
    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }
        [XmlArray("Departments"), XmlArrayItem("DeptItem")]
        public List<Dept> Departments { get; set; }
    }
}
