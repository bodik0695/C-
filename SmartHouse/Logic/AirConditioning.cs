using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class AirConditioning : Device, IAirConditioning
    {
        public int MaxHeatingModeTemperatureValue { get; set; }
        public int MinCoolingModeTemperatureValue { get; set; }
        public int TempForModeVentilation { get; set; }
        public Temperature Temperature { get; set; }
        public Mode Mode { get; set; }

        protected AirConditioning() { }
        public AirConditioning(bool power, AirConditioningModes acm, int maxHeatingModeTemperatureValue, int minCoolingModeTemperatureValue, int temperatureForVentilation, Temperature temper, Mode mod)
        {
            Power = power;
            Temperature = temper;
            Mode = mod;
            Mode.CurrentMode = (UniversalMode)acm;
            MaxHeatingModeTemperatureValue = maxHeatingModeTemperatureValue;
            MinCoolingModeTemperatureValue = minCoolingModeTemperatureValue;
            TempForModeVentilation = temperatureForVentilation;
        }

        public virtual void DecreaseTemperature()
        {
            if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.cooling)
            {
                Temperature.MinTemperatureValue = MinCoolingModeTemperatureValue;
                Temperature.DecreaseTemperature();
            }
            else if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.heating)
            {
                Temperature.MaxTemperatureValue = MaxHeatingModeTemperatureValue;
                Temperature.DecreaseTemperature();
            }
            else if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.ventilation)
            {

            }
        }

        public virtual void IncreaseTemperature()
        {
            if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.cooling)
            {
                Temperature.MinTemperatureValue = MinCoolingModeTemperatureValue;
                Temperature.IncreaseTemperature();
            }
            else if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.heating)
            {
                Temperature.MaxTemperatureValue = MaxHeatingModeTemperatureValue;
                Temperature.IncreaseTemperature();
            }
            else if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.ventilation)
            {

            }
        }

        public override void Off()
        {
            Power = false;
        }

        public override void On()
        {
            Power = true;
        }

        public virtual void SetModeCooling()
        {
            Mode.CurrentMode = (UniversalMode)AirConditioningModes.cooling;
        }

        public virtual void SetModeHeating()
        {
            Mode.CurrentMode = (UniversalMode)AirConditioningModes.heating;
        }

        public virtual void SetModeVentilation()
        {
            Mode.CurrentMode = (UniversalMode)AirConditioningModes.ventilation;
            Temperature.CurrentTemperature = TempForModeVentilation;
        }

        public override string ToString()
        {
            string mode = "";
            string power;
            string data = "";
            if (Power == true)
            {
                power = "включен";
            }
            else
            {
                power = "выключен";
            }
            if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.cooling)
            {
                mode = "охлаждение";
            }
            else if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.heating)
            {
                mode = "обогрев";
            }
            else if (Mode.CurrentMode == (UniversalMode)AirConditioningModes.ventilation)
            {
                mode = "вентиляция";
            }
            data = "Состояние: " + power + ", Режим: " + mode + ", Температура: " + Temperature.CurrentTemperature;
            return data;
        }
    }
}