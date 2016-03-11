using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Base
{
    public class Menu
    {
        Creation cr = new Creation();
        public ICreateEmployerRecordWithXML CreateEmployerRecordXML { get; set; }
        public IRemoveEmployeeRecordWithXML RemoveEmployeeRecordXML { get; set; }
        public IViewAllEmployeeRecordsWithXML ViewAllEmployeeRecordsXML { get; set; }
        public IViewRecordSpecificEmployeeXML ViewRecordSpecificEmployeeXML { get; set; }
        public ICreateEmployerRecordWithBIN CreateEmployerRecordBIN { get; set; }
        public IRemoveEmployeeRecordWithBIN RemoveEmployeeRecordBIN { get; set; }
        public IViewAllEmployeeRecordsWithBIN ViewAllEmployeeRecordsBIN { get; set; }
        public IViewRecordSpecificEmployeeBIN ViewRecordSpecificEmployeeBIN { get; set; }

        public Menu()
        {
            CreateEmployerRecordXML = cr.CreCreateEmployerRecordXML();
            RemoveEmployeeRecordXML = cr.CreateRemoveEmployeeRecordXML();
            ViewAllEmployeeRecordsXML = cr.CreateViewAllEmployeeRecordsXML();
            ViewRecordSpecificEmployeeXML = cr.CreateViewRecordSpecificEmployeeXML();
            CreateEmployerRecordBIN = cr.CreCreateEmployerRecordBIN();
            RemoveEmployeeRecordBIN = cr.CreateRemoveEmployeeRecordBIN();
            ViewAllEmployeeRecordsBIN = cr.CreateViewAllEmployeeRecordsBIN();
            ViewRecordSpecificEmployeeBIN = cr.CreateViewRecordSpecificEmployeeBIN();
        }

        public virtual void ConsoleMenu()
        {
            XmlSerializer xs = cr.CreateXmlSerializer();
            BinaryFormatter bf = cr.CreateBINSerializer();
            StreamReader sr = new StreamReader("option.ini");
            string serializeMode = sr.ReadLine();
            sr.Close();
            List<Employee> allPeople = new List<Employee>();
            IBaseEmployeesXML baseEmployeesXML = cr.CreateBaseEmployeesXML(CreateEmployerRecordXML, RemoveEmployeeRecordXML, ViewAllEmployeeRecordsXML, ViewRecordSpecificEmployeeXML);
            IBaseEmployeesBIN baseEmployeesBIN = cr.CreateBaseEmployeesBIN(CreateEmployerRecordBIN, RemoveEmployeeRecordBIN, ViewAllEmployeeRecordsBIN, ViewRecordSpecificEmployeeBIN);
            FileStream fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
            FileStream fs1 = new FileStream("baseEmployees.dat", FileMode.OpenOrCreate);
            if (fs.Length > 141 || fs1.Length > 0)
            {
                if (serializeMode == "XML")
                {
                    if (fs.Length > 141)
                    {
                        Employee[] prepreviousPeople = (Employee[])xs.Deserialize(fs);
                        allPeople = prepreviousPeople.ToList<Employee>();
                        Console.WriteLine("Загружен файл базы с предыдущей сессии");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                    }
                }
                else if (serializeMode == "BIN")
                {
                    if (fs1.Length > 0)
                    {
                        Employee[] prepreviousPeople = (Employee[])bf.Deserialize(fs1);
                        allPeople = prepreviousPeople.ToList<Employee>();
                        Console.WriteLine("Загружен файл базы с предыдущей сессии");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                    }
                }
                if (serializeMode == "XML" && fs.Length < 141 || serializeMode == "BIN" && fs1.Length <= 0)
                {
                    Console.WriteLine("Файл с предыдущей сессии не найден либо поврежден, создан новый файл базы");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
                fs.Close();
                fs1.Close();
            }
            else
            {
                fs.Close();
                fs1.Close();
                Console.WriteLine("Файл с предыдущей сессии не найден либо поврежден, создан новый файл базы");
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }

            while (true)
            {
                Employee[] allEmployees = allPeople.ToArray<Employee>();
                if (serializeMode == "XML")
                {
                    baseEmployeesXML.Create.CreateEmpRecordXML(xs, allEmployees);
                }
                else if (serializeMode == "BIN")
                {
                    baseEmployeesBIN.Create.CreateEmpRecordBIN(bf, allEmployees);
                }
                Console.Clear();
                Console.Write("Введите команду: ");
                string[] commands = Console.ReadLine().Split(' ');
                if (commands.Length != 1)
                {
                    Help();
                }
                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    return;
                }
                switch (commands[0].ToLower())
                {
                    case "add":
                        Console.WriteLine("Введите имя");
                        string regexInitials = @"^[A-ZА-Я'][a-zA-Zа-яА-Я-' ]+[a-zA-Zа-яА-Я']";
                        string regexPosition = @"^[a-zA-Zа-яА-Я'][a-zA-Zа-яА-Я-' ]+[a-zA-Zа-яА-Я']";
                        string regexAge = @"^\d{2}";
                        string regexMobileNumber = @"^\([0-9]{3}\)\s[0-9]{3}-[0-9]{2}-[0-9]{2}";
                        string regexEmail = @"^[a-zA-Z']+@+gmail.com";
                        string name = "";
                        string tempName = Console.ReadLine();
                        if (Regex.IsMatch(tempName, regexInitials))
                        {
                            name = tempName;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод имени");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Введите фамилию");
                        string surname = "";
                        string tempSurname = Console.ReadLine();
                        if (Regex.IsMatch(tempSurname, regexInitials))
                        {
                            surname = tempSurname;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод фамилии");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Введите отчество");
                        string patronymic = "";
                        string tempPatronymic = Console.ReadLine();
                        if (Regex.IsMatch(tempPatronymic, regexInitials))
                        {
                            patronymic = tempPatronymic;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод отчества");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Введите возраст");
                        string age = "";
                        string tempAge = Console.ReadLine();
                        if (Regex.IsMatch(tempAge, regexAge))
                        {
                            age = tempAge;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод возраста");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Введите должность");
                        string position = "";
                        string tempPosition = Console.ReadLine();
                        if (Regex.IsMatch(tempPosition, regexPosition))
                        {
                            position = tempPosition;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод должности");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Введите мобильный телефон в формате (ххх) ххх-хх-хх");
                        string mobilePhoneNumber = "";
                        string tempMobilePhoneNumber = Console.ReadLine();
                        if (Regex.IsMatch(tempMobilePhoneNumber, regexMobileNumber))
                        {
                            mobilePhoneNumber = tempMobilePhoneNumber;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод номера");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Введите email в формате <>@gmail.com");
                        string email = "";
                        string tempEmail = Console.ReadLine();
                        if (Regex.IsMatch(tempEmail, regexEmail))
                        {
                            email = tempEmail;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод почтового адреса");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            break;
                        }
                        if (allPeople.Count == 0)
                        {
                            allPeople.Add(cr.CreateEmployee(surname, name, patronymic, age, position, mobilePhoneNumber, email));
                        }
                        else
                        {
                            foreach (Employee p in allPeople)
                            {
                                if (p.Name != name && p.Surname != surname && p.Patronymic != patronymic)
                                {
                                    allPeople.Add(cr.CreateEmployee(surname, name, patronymic, age, position, mobilePhoneNumber, email));
                                    Console.WriteLine("Запись добавлена");
                                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("В базе уже числится сотрудник с такими инициалами");
                                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;
                    case "del":
                        Console.WriteLine("Введите имя");
                        string nameRem = Console.ReadLine();
                        Console.WriteLine("Введите фамилию");
                        string surnameRem = Console.ReadLine();
                        if (serializeMode == "XML")
                        {
                            fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
                            if (fs.Length > 141)
                            {
                                baseEmployeesXML.Remove.RemoveEmpRecordXML(nameRem, surnameRem, xs);
                                Console.WriteLine("Запись удалена");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("База пуста");
                            }
                            fs.Close();
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }
                        else if (serializeMode == "BIN")
                        {
                            fs = new FileStream("baseEmployees.dat", FileMode.OpenOrCreate);
                            if (fs.Length > 0)
                            {
                                baseEmployeesBIN.Remove.RemoveEmpRecordBIN(nameRem, surnameRem, bf);
                                Console.WriteLine("Запись удалена");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("База пуста");
                            }
                            fs.Close();
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }
                        break;
                    case "del_all":
                        allPeople.Clear();
                        break;
                    case "view_all":
                        if (serializeMode == "XML")
                        {
                            fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
                            if (fs.Length > 141)
                            {
                                fs.Close();
                                baseEmployeesXML.ViewAll.ViewAllEmpRecordsXML(xs);
                            }
                            else
                            {
                                Console.WriteLine("База пуста");
                            }
                            fs.Close();
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }
                        else if (serializeMode == "BIN")
                        {
                            fs = new FileStream("baseEmployees.dat", FileMode.OpenOrCreate);
                            if (fs.Length > 0)
                            {
                                fs.Close();
                                baseEmployeesBIN.ViewAll.ViewAllEmpRecordsBIN(bf);
                            }
                            else
                            {
                                Console.WriteLine("База пуста");
                            }
                            fs.Close();
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    case "view_spec":
                        Console.WriteLine("Введите имя");
                        string nameView = Console.ReadLine();
                        Console.WriteLine("Введите фамилию");
                        string surnameView = Console.ReadLine();
                        if (serializeMode == "XML")
                        {
                            fs = new FileStream("baseEmployees.xml", FileMode.OpenOrCreate);
                            if (fs.Length > 141)
                            {
                                fs.Close();
                                baseEmployeesXML.ViewSpec.ViewRecSpecEmpXML(nameView, surnameView, xs);
                            }
                            else
                            {
                                Console.WriteLine("Соответствий не найдено либо база пуста");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            fs.Close();
                        }
                        else if (serializeMode == "BIN")
                        {
                            fs = new FileStream("baseEmployees.dat", FileMode.OpenOrCreate);
                            if (fs.Length > 0)
                            {
                                fs.Close();
                                baseEmployeesBIN.ViewSpec.ViewRecSpecEmpBIN(nameView, surnameView, bf);
                            }
                            else
                            {
                                Console.WriteLine("Соответствий не найдено либо база пуста");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                            }
                            fs.Close();
                        }
                        break;
                    case "exit":
                        break;
                    default:
                        Help();
                        break;
                }
            }
        }
        private static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tДобавить запись о сотруднике в базу: add");
            Console.WriteLine("\tУдалить запись о сотруднике из базы: del");
            Console.WriteLine("\tУдалить все записи о сотрудниках из базы: del_all");
            Console.WriteLine("\tПросмотреть все записи о сотрудниках: view_all");
            Console.WriteLine("\tПросмотреть конкретную запись о сотрудниках: view_spec");
            Console.WriteLine("\tФормат ввода номера (ххх) ххх-хх-хх");
            Console.WriteLine("Нажмите любую клавишу для продолжения: ");
            Console.ReadKey();
        }
    }
}