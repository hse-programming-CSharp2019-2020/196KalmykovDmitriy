using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Task_6
{
    internal class Program
    {
        private static void Main()
        {
            var HSE = new University { UniversityName = "NRU HSE" };

            Professor[] deptStaff = { new Professor("Ivanov"),
                new Professor("Petrov")
            };

            var SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept> {SE};

            var xmlSerializer = new XmlSerializer(typeof(University),
                new[] { typeof(Human), typeof(Professor), typeof(Dept) });

            // Сериализация
            using (Stream file = new FileStream("XmlSer.xml", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(file, HSE);
            }

            // Десериализация
            University HSEdeserial;

            using (Stream file = File.OpenRead("XmlSer.xml"))
            {
                HSEdeserial = (University)xmlSerializer.Deserialize(file);
            }

            foreach (var dept in HSEdeserial.Departments)
            foreach (var prof in dept.Staff.OfType<Professor>()) Console.WriteLine(dept.DeptName + " prof.: " + prof.Name);
        }
    }
}
