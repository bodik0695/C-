using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
     public class DeviceCreator
    {
        public virtual IFridge CreateFridge()
        {
            IFridge device = new Fridge(false, FridgeModes.normal, 6, 4, 7, 0, new Temperature(4, 0, 8), new Mode());
            return device;
        }
        public virtual IFreezer CreateFreezer()
        {
            IFreezer device = new Freezer(FreezerModes.freezing, -24, -18, -12, new Temperature(-18, -24, -12), new Mode());
            device.DisableFrifge("");
            return device;
        }
        public virtual IHeater CreateHeater()
        {
            IHeater device = new Heater(false, HeaterModes.inRoom, 25, 10, new Temperature(10, 0, 40), new Mode());
            return device;
        }
        public virtual IAirConditioning CreateAirConditioning()
        {
            IAirConditioning device = new AirConditioning(false, AirConditioningModes.cooling, 20, 5, 20, new Temperature(20, -5, 35), new Mode());
            return device;
        }
        public virtual ITV CreateTV()
        {
            ITV device = new TV(false, new Sound(10, 0, 100, 1), new Channel(1, 1, 100));
            return device;
        }
        public virtual IMediaPlayer CreateMediaPlayer()
        {
            IMediaPlayer device = new MediaPlayer(false, PlayerModes.stop, false, new Sound(10, 0, 100, 1), new TrackControl(1), new Mode());
            string[] tracks = new string[] { "one", "two", "thre" };
            Disc disc = new Disc("Пробный", tracks);
            device.InsertDisc(disc);
            return device;
        }
    }
}