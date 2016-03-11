using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public interface IViewAllEmployeeRecordsWithXML
    {
        void ViewAllEmpRecordsXML(XmlSerializer xs);
    }
}