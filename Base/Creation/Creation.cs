using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public class Creation
    {
        public virtual Employee CreateEmployee(string surname, string name, string patronymic, string age, string position, string mobilePhoneNumber, string email)
        {
            Employee employee = new Employee();
            employee.Surname = surname;
            employee.Name = name;
            employee.Patronymic = patronymic;
            employee.Age = age;
            employee.Position = position;
            employee.MobilePhoneNumber = mobilePhoneNumber;
            employee.Email = email;
            return employee;
        }
        public virtual ICreateEmployerRecordWithXML CreCreateEmployerRecordXML()
        {
            ICreateEmployerRecordWithXML record = new CreateEmployerRecordXML();
            return record;
        }
        public virtual IRemoveEmployeeRecordWithXML CreateRemoveEmployeeRecordXML()
        {
            IRemoveEmployeeRecordWithXML remove = new RemoveEmployeeRecordXML();
            return remove;
        }
        public virtual IViewAllEmployeeRecordsWithXML CreateViewAllEmployeeRecordsXML()
        {
            IViewAllEmployeeRecordsWithXML viewAll = new ViewAllEmployeeRecordsXML();
            return viewAll;
        }
        public virtual IViewRecordSpecificEmployeeXML CreateViewRecordSpecificEmployeeXML()
        {
            IViewRecordSpecificEmployeeXML viewSpec = new ViewRecordSpecificEmployeeXML();
            return viewSpec;
        }
        public virtual XmlSerializer CreateXmlSerializer()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Employee[]));
            return xs;
        }
        public virtual IBaseEmployeesXML CreateBaseEmployeesXML(ICreateEmployerRecordWithXML create, IRemoveEmployeeRecordWithXML remove, IViewAllEmployeeRecordsWithXML viewAll, IViewRecordSpecificEmployeeXML viewSpe)
        {
            IBaseEmployeesXML baseEmp = new BaseEmployeesXML(create, remove, viewAll, viewSpe);
            return baseEmp;
        }

        public virtual ICreateEmployerRecordWithBIN CreCreateEmployerRecordBIN()
        {
            ICreateEmployerRecordWithBIN record = new CreateEmployerRecordBIN();
            return record;
        }
        public virtual IRemoveEmployeeRecordWithBIN CreateRemoveEmployeeRecordBIN()
        {
            IRemoveEmployeeRecordWithBIN remove = new RemoveEmployeeRecordBIN();
            return remove;
        }
        public virtual IViewAllEmployeeRecordsWithBIN CreateViewAllEmployeeRecordsBIN()
        {
            IViewAllEmployeeRecordsWithBIN viewAll = new ViewAllEmployeeRecordsBIN();
            return viewAll;
        }
        public virtual IViewRecordSpecificEmployeeBIN CreateViewRecordSpecificEmployeeBIN()
        {
            IViewRecordSpecificEmployeeBIN viewSpec = new ViewRecordSpecificEmployeeBIN();
            return viewSpec;
        }
        public virtual BinaryFormatter CreateBINSerializer()
        {
            BinaryFormatter bf = new BinaryFormatter();
            return bf;
        }
        public virtual IBaseEmployeesBIN CreateBaseEmployeesBIN(ICreateEmployerRecordWithBIN create, IRemoveEmployeeRecordWithBIN remove, IViewAllEmployeeRecordsWithBIN viewAll, IViewRecordSpecificEmployeeBIN viewSpe)
        {
            IBaseEmployeesBIN baseEmp = new BaseEmployeesBIN(create, remove, viewAll, viewSpe);
            return baseEmp;
        }
    }
}