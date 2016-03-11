using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public class ViewAllEmployeeRecordsXML : IViewAllEmployeeRecordsWithXML
    {
        public ViewAllEmployeeRecordsXML()
        { }
        public virtual void ViewAllEmpRecordsXML(XmlSerializer xs)
        {
            FileStream fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
            Employee[] newPeople = (Employee[])xs.Deserialize(fs);
            using (fs)
            {
                List<Employee> allPeople = newPeople.ToList<Employee>();
                int counter = 0;
                foreach (Employee p in allPeople)
                {
                    Console.WriteLine("Фамилия: " + allPeople[counter].Surname + "\r\nИмя: " + allPeople[counter].Name + "\r\nОтчество: " + allPeople[counter].Patronymic + "\r\nВозраст: " + allPeople[counter].Age + "\r\nДолжность: " + allPeople[counter].Position + "\r\nМобильный телефон: " + allPeople[counter].MobilePhoneNumber + "\r\nEmail: " + allPeople[counter].Email);
                    Console.WriteLine();
                }
            }
            fs.Close();
        }
    }
}