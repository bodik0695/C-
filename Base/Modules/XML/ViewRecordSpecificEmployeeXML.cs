using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public class ViewRecordSpecificEmployeeXML : IViewRecordSpecificEmployeeXML
    {
        public ViewRecordSpecificEmployeeXML()
        { }

        public virtual void ViewRecSpecEmpXML(string name, string surname, XmlSerializer xs)
        {
            FileStream fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
            Employee[] newPeople = (Employee[])xs.Deserialize(fs);
            using (fs)
            {
                List<Employee> allPeople = newPeople.ToList<Employee>();
                int counter = 0;
                foreach (Employee p in allPeople)
                {
                    if (p.Name == name && p.Surname == surname)
                    {
                        Console.WriteLine("Пользователь найден:");
                        Console.WriteLine("Фамилия: " + allPeople[counter].Surname + "\r\nИмя: " + allPeople[counter].Name + "\r\nОтчество: " + allPeople[counter].Patronymic + "\r\nВозраст: " + allPeople[counter].Age + "\r\nДолжность: " + allPeople[counter].Position + "\r\nМобильный телефон: " + allPeople[counter].MobilePhoneNumber + "\r\nEmail: " + allPeople[counter].Email);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    counter++;
                }
            }
            fs.Close();
        }
    }
}