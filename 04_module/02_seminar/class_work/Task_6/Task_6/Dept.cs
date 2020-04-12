using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Task_6
{
    [Serializable]
    public class Dept
    {
        [XmlAttribute("DeptName")]
        public string DeptName { get; set; }
        List<Human> staff;
        [XmlArray("Staff"), XmlArrayItem("StaffItem")]
        public List<Human> Staff
        {
            get => staff;
            set => staff = value;
        }
        public Dept() { }
        public Dept(string name, IEnumerable<Human> staffList)
        {
            DeptName = name;
            staff = new List<Human>(staffList);
        }
    }

}
