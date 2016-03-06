using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Temperature : ITemperature
    {
        public int CurrentTemperature { get; set; }
        public int MinTemperatureValue { get; set; }
        public int MaxTemperatureValue { get; set; }

        protected Temperature() { }
        public Temperature(int currentTemperature, int minTemperatureValue, int maxTemperatureValue)
        {
            if (currentTemperature >= minTemperatureValue && currentTemperature <= maxTemperatureValue)
            {
                CurrentTemperature = currentTemperature;
            }
            MinTemperatureValue = minTemperatureValue;
            MaxTemperatureValue = maxTemperatureValue;
        }

        public virtual void DecreaseTemperature()
        {
            while (CurrentTemperature > MinTemperatureValue && CurrentTemperature <= MaxTemperatureValue)
            {
                CurrentTemperature--;
            }
        }

        public virtual void IncreaseTemperature()
        {
            while (CurrentTemperature >= MinTemperatureValue && CurrentTemperature < MaxTemperatureValue)
            {
                CurrentTemperature++;
            }
        }
    }
}