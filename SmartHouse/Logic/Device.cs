using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public abstract class Device : IDevice
    {
        public bool Power { get; set; }
        public abstract void On();
        public abstract void Off();
    }
}