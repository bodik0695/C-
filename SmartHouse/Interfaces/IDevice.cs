using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IDevice
    {
        bool Power { get; set; }
        void On();
        void Off();
    }
}