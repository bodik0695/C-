using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            DeviceCreator dc = new DeviceCreator();
            Menu menu = new Menu(dc.CreateFridge(), dc.CreateHeater(), dc.CreateFreezer(), dc.CreateAirConditioning(), dc.CreateTV(), dc.CreateMediaPlayer());
            menu.ConsoleMenu();
        }
    }
}
