using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IAirConditioning : IDevice
    {
        Temperature Temperature { get; set; }
        Mode Mode { get; set; }

        void DecreaseTemperature();
        void IncreaseTemperature();
        void SetModeCooling();
        void SetModeHeating();
        void SetModeVentilation();
        string ToString();
    }
}