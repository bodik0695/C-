using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface ITemperature
    {
        int CurrentTemperature { get; set; }
        int MinTemperatureValue { get; set; }
        int MaxTemperatureValue { get; set; }
        void IncreaseTemperature();
        void DecreaseTemperature();
    }
}