using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    [Serializable]
    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Age { get; set; }
        public string Position { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }

        public Employee()
        { }

        public Employee(string surname, string name, string patronymic, string age, string position, string mobilePhoneNumber, string email)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Age = age;
            Position = position;
            MobilePhoneNumber = mobilePhoneNumber;
            Email = email;
        }
    }
}