using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Display
    {
        public virtual string ShowSpecificationDevice(object o)
        {
            string temp = "";
            if (o.GetType() == new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode()).GetType())
            {
                Fridge f = (Fridge)o;
                string power;
                string mode = "";
                if (f.Power == true)
                {
                    power = "включен";
                }
                else
                {
                    power = "выключен";
                }
                if (f.Mode.CurrentMode == (UniversalMode)FridgeModes.manual)
                {
                    mode = "Пользовательский";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)FridgeModes.normal)
                {
                    mode = "Нормальный";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)FridgeModes.warm)
                {
                    mode = "Теплый";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)FridgeModes.lowTemperature)
                {
                    mode = "Низких температур";
                }
                temp = "Состояние: " + power + ", Режим: " + mode + ", Температура: " + f.Temperature.CurrentTemperature;
            }
            if (o.GetType() == new Freezer(FreezerModes.freezing, -24, -18, -12, new Temperature(-18, -24, -12), new Mode()).GetType())
            {
                Freezer f = (Freezer)o;
                string mode = "";
                if (f.Mode.CurrentMode == (UniversalMode)FreezerModes.fastFreeze)
                {
                    mode = "Быстрая заморозка";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)FreezerModes.freezing)
                {
                    mode = "Заморозка";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)FreezerModes.storage)
                {
                    mode = "Хранение";
                }
                temp = "Режим: " + mode;
            }
            if (o.GetType() == new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode()).GetType())
            {
                Heater f = (Heater)o;
                string power;
                string mode = "";
                if (f.Power == true)
                {
                    power = "включен";
                }
                else
                {
                    power = "выключен";
                }
                if (f.Mode.CurrentMode == (UniversalMode)HeaterModes.inRoom)
                {
                    mode = "В помещении";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)HeaterModes.onStreet)
                {
                    mode = "На улице";
                }
                temp = "Состояние: " + power + ", Режим: " + mode + ", Температура: " + f.Temperature.CurrentTemperature;
            }
            if (o.GetType() == new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode()).GetType())
            {
                AirConditioning f = (AirConditioning)o;
                string mode = "";
                string power;
                if (f.Power == true)
                {
                    power = "включен";
                }
                else
                {
                    power = "выключен";
                }
                if (f.Mode.CurrentMode == (UniversalMode)AirConditioningModes.cooling)
                {
                    mode = "Охлаждение";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)AirConditioningModes.heating)
                {
                    mode = "Обогрев";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)AirConditioningModes.ventilation)
                {
                    mode = "Вентиляция";
                }
                temp = "Состояние: " + power + ", Режим: " + mode + ", Температура: " + f.Temperature.CurrentTemperature;
            }
            if (o.GetType() == new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100)).GetType())
            {
                TV f = (TV)o;
                string power;
                if (f.Power == true)
                {
                    power = "включен";
                }
                else
                {
                    power = "выключен";
                }
                temp = "Состояние: " + power + ", Канал: " + f.Channel.CurrentChannel +  ", Громкость: " + f.Sound.CurrentVolume;
            }
           
            if (o.GetType() == new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode()).GetType())
            {
                MediaPlayer f = (MediaPlayer)o;
                string power;
                string discPresence = "";
                string mode = "";
                if (f.DiscPresence == true)
                {
                    discPresence = "диск " + "\"" + f.TrackControl.CurrentDiskName + "\"" + " обнаружен";
                }
                else
                {
                    discPresence = "отсутствует";
                }
                if (f.Power == true)
                {
                    power = "включен";
                }
                else
                {
                    power = "выключен";
                }
                if (f.Mode.CurrentMode == (UniversalMode)PlayerModes.pause)
                {
                    mode = "пауза";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)PlayerModes.play)
                {
                    mode = "проигрывание";
                }
                else if (f.Mode.CurrentMode == (UniversalMode)PlayerModes.stop)
                {
                    mode = "остановлен";
                }
                temp = "Состояние: " + power +", Режим: "+ mode +", Количество треков: " + f.TrackControl.Tracks.Length + ", Текущий трек: " + f.TrackControl.CurrentTrack + "-" + "\"" + f.TrackControl.CurrentTrackName + "\"" + ", Громкость: " + f.Sound.CurrentVolume + ", Наличие диска: " + discPresence;
            }
            return temp;
        }
    }
}


