using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public interface IRemoveEmployeeRecordWithXML
    {
        void RemoveEmpRecordXML(string name, string surname, XmlSerializer xs);
    }
}