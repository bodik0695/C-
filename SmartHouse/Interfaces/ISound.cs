using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface ISound
    {
        int CurrentVolume { get; set; }
        int MinVolume { get; set; }
        int MaxVolume { get; set; }
        void IncreaseSound();
        void DecreaseSound();
        void SoundOff();
        void SoundOn();
    }
}