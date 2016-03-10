using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BaseEmployees
{
    public interface IViewRecordSpecificEmployeeXML
    {
        void ViewRecSpecEmpXML(string name, string surname, XmlSerializer xs);
    }
}