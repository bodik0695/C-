using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    public interface IEmployee
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        string Age { get; set; }
        string Position { get; set; }
        string MobilePhoneNumber { get; set; }
        string Email { get; set; }
    }
}