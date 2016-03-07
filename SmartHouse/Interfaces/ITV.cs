using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface ITV : IDevice
    {
        Sound Sound { get; set; }
        Channel Channel { get; set; }

        void DecreaseSound();
        void IncreaseSound();
        void NextChannel();
        void PreviousChannel();
        void SelectChannel(int channelNumber);
        void SoundOff();
        void SoundOn();
        string ToString();
    }
}