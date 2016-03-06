using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public abstract class TemperatureDevice 
    {
        public int CurrentTemperature { get; set; }
        public abstract void DecreaseTemperature();
        public abstract void IncreaseTemperature();
    }
}