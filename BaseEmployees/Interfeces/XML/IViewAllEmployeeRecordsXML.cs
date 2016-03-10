using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BaseEmployees
{
    public interface IViewAllEmployeeRecordsWithXML
    {
        void ViewAllEmpRecordsXML(XmlSerializer xs);
    }
}