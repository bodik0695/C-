using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IFridge : IDevice
    {
        bool PresenceFreezer { get; set; }
        string CurrentFreezerName { get; set; }
        Temperature Temperature { get; set; }
        Mode Mode { get; set; }

        void DecreaseTemperature();
        void IncreaseTemperature();
        void SetManualMode();
        void SetNormalMode();
        void SetWarmMode();
        void SetLowTemperatureMode();
        void ConnectFreezer(string freezerName);
        void DisableFreezer(string freezerName);
        string ToString();
    }
}