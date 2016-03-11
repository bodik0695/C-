using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    public class BaseEmployeesXML : IBaseEmployeesXML
    {
        public IEmployee[] AllEmployees { get; set; }
        public ICreateEmployerRecordWithXML Create { get; set; }
        public IRemoveEmployeeRecordWithXML Remove { get; set; }
        public IViewAllEmployeeRecordsWithXML ViewAll { get; set; }
        public IViewRecordSpecificEmployeeXML ViewSpec { get; set; }

        public BaseEmployeesXML()
        { }
        public BaseEmployeesXML(ICreateEmployerRecordWithXML create, IRemoveEmployeeRecordWithXML remove, IViewAllEmployeeRecordsWithXML viewAll, IViewRecordSpecificEmployeeXML viewSpe)
        {
            Create = create;
            Remove = remove;
            ViewAll = viewAll;
            ViewSpec = viewSpe;
        }
    }
}