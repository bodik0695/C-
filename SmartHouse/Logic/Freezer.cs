using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Freezer : Fridge, IFreezer
    {
        public int TempForFastFreezeMode { get; private set; }
        public int TempForFreezingMode { get; private set; }
        public int TempForStorageMode { get; private set; }
        public string CurrentFridge { get; set; }
        public bool PresenceFridge { get; set; }
        public Temperature Temper { get; set; }
        public Mode Mod { get; set; }

        public Freezer(FreezerModes fMode, int tempForFastFreezeMode, int tempForFreezingMode, int tempForStorageMode, Temperature temper, Mode mod)
        {
            Temper = temper;
            Mod = mod;
            Mod.CurrentMode = (UniversalMode)fMode;
            TempForFastFreezeMode = tempForFastFreezeMode;
            TempForFreezingMode = tempForFreezingMode;
            TempForStorageMode = tempForStorageMode;
        }
        public virtual void SetFastFreezeMode()
        {
            Mod.CurrentMode = (UniversalMode)FreezerModes.fastFreeze;
            Temper.CurrentTemperature = TempForFastFreezeMode;
        }

        public virtual void SetFreezingMode()
        {
            Mod.CurrentMode = (UniversalMode)FreezerModes.freezing;
            Temper.CurrentTemperature = TempForFreezingMode;
        }

        public virtual void SetStorageMode()
        {
            Mod.CurrentMode = (UniversalMode)FreezerModes.storage;
            Temper.CurrentTemperature = TempForStorageMode;
        }
        public virtual void ConnectFridge(string fridgeName)
        {
            PresenceFridge = true;
            CurrentFridge = fridgeName;
        }

        public virtual void DisableFrifge(string fridgeName)
        {
            PresenceFridge = false;
            string temp = "";
            CurrentFridge = temp;
        }

        public override string ToString()
        {
            string mode = "";
            string fridgeName = "";
            string data = "";
            if (Mod.CurrentMode == (UniversalMode)FreezerModes.fastFreeze)
            {
                mode = "быстрая заморозка";
            }
            else if (Mod.CurrentMode == (UniversalMode)FreezerModes.freezing)
            {
                mode = "заморозка";
            }
            else if (Mod.CurrentMode == (UniversalMode)FreezerModes.storage)
            {
                mode = "хранение";
            }
            if (PresenceFridge)
            {
                fridgeName = CurrentFridge;
            }
            else
            {
                fridgeName = "";
            }
            data = "Режим: " + mode + ", Подключена к: " + fridgeName;
            return data;
        }
    }
}