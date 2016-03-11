using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public class RemoveEmployeeRecordXML : IRemoveEmployeeRecordWithXML
    {
        public RemoveEmployeeRecordXML()
        { }

        public virtual void RemoveEmpRecordXML(string name, string surname, XmlSerializer xs)
        {
            FileStream fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
            Employee[] remPeople = (Employee[])xs.Deserialize(fs);
            using (fs)
            {
                List<Employee> allPeople = remPeople.ToList<Employee>();
                int counter = 0;
                foreach (Employee p in allPeople)
                {
                    if (p.Name == name && p.Surname == surname)
                    {

                        allPeople.RemoveAt(counter);
                        remPeople = allPeople.ToArray<Employee>();
                        break;
                    }
                    counter++;
                }
            }
            fs.Close();
            fs = new FileStream("baseEmployees.xml", FileMode.Create);
            using (fs)
            {
                xs.Serialize(fs, remPeople);
                fs.Close();
            }
        }
    }
}