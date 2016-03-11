using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public interface ICreateEmployerRecordWithXML
    {
        void CreateEmpRecordXML(XmlSerializer xs, Employee[] people);
    }
}