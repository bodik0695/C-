﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Heater : Device, IHeater
    {
        public int TempForModeStreet { get; set; }
        public int TempForModeInRoom { get; set; }
        public Temperature Temperature { get; set; }
        public Mode Mode { get; set; }

        protected Heater() { }
        public Heater(bool power, HeaterModes hm, int tempForModeStreet, int tempForModeInRoom, Temperature temper, Mode mod)
        {
            Power = power;
            Temperature = temper;
            Mode = mod;
            Mode.CurrentMode = (UniversalMode)hm;
            TempForModeInRoom = tempForModeInRoom;
            TempForModeStreet = tempForModeStreet;
        }

        public override void Off()
        {
            Power = false;
        }

        public override void On()
        {
            Power = true;
        }

        public virtual void DecreaseTemperature()
        {
            Temperature.DecreaseTemperature();
        }

        public virtual void IncreaseTemperature()
        {
            Temperature.IncreaseTemperature();
        }

        public virtual void SetModeInRoom()
        {
            Mode.CurrentMode = (UniversalMode)HeaterModes.inRoom;
            Temperature.CurrentTemperature = TempForModeInRoom;
        }

        public virtual void SetModeOnStreet()
        {
            Mode.CurrentMode = (UniversalMode)HeaterModes.onStreet;
            Temperature.CurrentTemperature = TempForModeStreet;
        }

        public override string ToString()
        {
            string power;
            string mode = "";
            string data = "";
            if (Power == true)
            {
                power = "включен";
            }
            else
            {
                power = "выключен";
            }
            if (Mode.CurrentMode == (UniversalMode)HeaterModes.inRoom)
            {
                mode = "В помещении";
            }
            else if (Mode.CurrentMode == (UniversalMode)HeaterModes.onStreet)
            {
                mode = "На улице";
            }
            data = "Состояние: " + power + ", Режим: " + mode + ", Температура: " + Temperature.CurrentTemperature;
            return data;
        }
    }
}