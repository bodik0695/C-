using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Fridge : Device
    {
        public int TempForManualMode { get; private set; }
        public int TempForNormalMode { get; private set; }
        public int TempForWarmMode { get; private set; }
        public int TempForLowTemperatureMode { get; private set; }
        public Temperature Temperature { get; set; }
        public Mode Mode { get; set; }

        protected Fridge() { }
        public Fridge(bool power, FridgeModes fm,  int tempForManualMode, int tempForNormalMode, int tempForWarmMode, int tempForLowTemperatureMode, Temperature temper, Mode mod)
        {
            Power = power;
            Mode = mod;
            Mode.CurrentMode = (UniversalMode)fm;
            TempForManualMode = tempForManualMode;
            TempForNormalMode = tempForNormalMode;
            TempForWarmMode = tempForWarmMode;
            TempForLowTemperatureMode = tempForLowTemperatureMode;
            Temperature = temper;
        }

        public override void On()
        {
            Power = true;
        }

        public override void Off()
        {
            Power = false;
        }

        public virtual void DecreaseTemperature()
        {
            if (Mode.CurrentMode == (UniversalMode)FridgeModes.manual)
            {
                Temperature.DecreaseTemperature();
            }
        }

        public virtual void IncreaseTemperature()
        {
            if (Mode.CurrentMode == (UniversalMode)FridgeModes.manual)
            {
                Temperature.IncreaseTemperature();
            }
        }

        public virtual void SetManualMode()
        {
            Mode.CurrentMode = (UniversalMode)FridgeModes.manual;
            Temperature.CurrentTemperature = TempForManualMode;
        }

        public virtual void SetNormalMode()
        {
            Mode.CurrentMode = (UniversalMode)FridgeModes.normal;
            Temperature.CurrentTemperature = TempForNormalMode;
        }

        public virtual void SetWarmMode()
        {
            Mode.CurrentMode = (UniversalMode)FridgeModes.warm;
            Temperature.CurrentTemperature = TempForWarmMode;
        }

        public virtual void SetLowTemperatureMode()
        {
            Mode.CurrentMode = (UniversalMode)FridgeModes.lowTemperature;
            Temperature.CurrentTemperature = TempForLowTemperatureMode;
        }
    }
}