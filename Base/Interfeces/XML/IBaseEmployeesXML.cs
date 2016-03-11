using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    public interface IBaseEmployeesXML
    {
        IEmployee[] AllEmployees { get; set; }
        ICreateEmployerRecordWithXML Create { get; set; }
        IRemoveEmployeeRecordWithXML Remove { get; set; }
        IViewAllEmployeeRecordsWithXML ViewAll { get; set; }
        IViewRecordSpecificEmployeeXML ViewSpec { get; set; }
    }
}