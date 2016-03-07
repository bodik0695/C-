using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IHeater : IDevice
    {
        Temperature Temperature { get; set; }
        Mode Mode { get; set; }

        void DecreaseTemperature();
        void IncreaseTemperature();
        void SetModeInRoom();
        void SetModeOnStreet();
        string ToString();
    }
}