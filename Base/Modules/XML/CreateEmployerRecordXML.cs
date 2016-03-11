using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Base
{
    public class CreateEmployerRecordXML : ICreateEmployerRecordWithXML
    {
        public CreateEmployerRecordXML()
        { }

        public virtual void CreateEmpRecordXML(XmlSerializer xs, Employee[] people)
        {
            FileStream fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
            if (fs.Length > 141)
            {
                Employee[] currentPeople = (Employee[])xs.Deserialize(fs);
                fs.Close();
                fs = new FileStream("baseEmployees.xml", FileMode.Create);
                using (fs)
                {
                    if (currentPeople.Length == 0)
                    {
                        xs.Serialize(fs, people);
                        fs.Close();
                    }
                    else
                    {
                        for (int z = 0; z < currentPeople.Length; z++)
                        {
                            if (people.Length > 1)
                            {
                                if (currentPeople[z].Name != people[people.Length - 1].Name && currentPeople[z].Surname != people[people.Length - 1].Surname && currentPeople[z].Patronymic != people[people.Length - 1].Patronymic)
                                {
                                    xs.Serialize(fs, people);
                                    fs.Close();
                                }
                                else
                                {
                                    xs.Serialize(fs, currentPeople);
                                    fs.Close();
                                }
                            }
                            else
                            {
                                xs.Serialize(fs, people);
                                fs.Close();
                            }
                        }
                    }
                }
                fs.Close();
            }
            else
            {
                if (people.Length != 0)
                {
                    fs.Close();
                    FileStream fs1 = new FileStream("baseEmployees.xml", FileMode.Create);
                    using (fs1)
                    {
                        xs.Serialize(fs1, people);
                        fs1.Close();
                    }
                }
            }
            fs.Close();
        }
    }
}