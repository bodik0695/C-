using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Freezer : Fridge
    {   
        public int TempForFastFreezeMode { get; private set; }
        public int TempForFreezingMode { get; private set; }
        public int TempForStorageMode { get; private set; }
        public Temperature Temperature { get; set; }
        public Mode Mode { get; set; }

        public Freezer(FreezerModes fMode, int tempForFastFreezeMode, int tempForFreezingMode, int tempForStorageMode, Temperature temper, Mode mod)
        {
            Temperature = temper;
            Mode = mod;
            Mode.CurrentMode =(UniversalMode)fMode;
            TempForFastFreezeMode = tempForFastFreezeMode;
            TempForFreezingMode = tempForFreezingMode;
            TempForStorageMode = tempForStorageMode;
        }
        public virtual void SetFastFreezeMode()
        {
            Mode.CurrentMode = (UniversalMode)FreezerModes.fastFreeze;
            Temperature.CurrentTemperature = TempForFastFreezeMode;
        }

        public virtual void SetFreezingMode()
        {
            Mode.CurrentMode = (UniversalMode)FreezerModes.freezing;
            Temperature.CurrentTemperature = TempForFreezingMode;
        }

        public virtual void SetStorageMode()
        {
            Mode.CurrentMode = (UniversalMode)FreezerModes.storage;
            Temperature.CurrentTemperature = TempForStorageMode;
        }
    }
}