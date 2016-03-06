using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Sound : ISound
    {
        public int CurrentVolume { get; set; }
        public int MinVolume { get; set; }
        public int MaxVolume { get; set; }
        public int MagnitudeOfVolumeChange { get; set; }
        private int tempVolume;

        protected Sound() { }
        public Sound(int currentVolume, int minVolume, int maxVolume, int magnitudeOfVolumeChange)
        {
            if (currentVolume > minVolume && currentVolume <= maxVolume)
            {
                CurrentVolume = currentVolume;
            }
            if (minVolume >= 0)
            {
                MinVolume = minVolume;
            }
            if (maxVolume > MinVolume)
            {
                MaxVolume = maxVolume;
            }
            if (MaxVolume % magnitudeOfVolumeChange == 0 && magnitudeOfVolumeChange < MaxVolume / 2 && magnitudeOfVolumeChange > MinVolume)
            {
                MagnitudeOfVolumeChange = magnitudeOfVolumeChange;
            }
        }

        public virtual void DecreaseSound()
        {
            if (CurrentVolume > MinVolume && CurrentVolume <= MaxVolume)
            {
                CurrentVolume -= MagnitudeOfVolumeChange;
            }
        }

        public virtual void IncreaseSound()
        {
            if (CurrentVolume >= MinVolume && CurrentVolume < MaxVolume)
            {
                CurrentVolume += MagnitudeOfVolumeChange;
            }
        }

        public virtual void SoundOff()
        {
            tempVolume = CurrentVolume;
            CurrentVolume = MinVolume;
        }

        public virtual void SoundOn()
        {
            CurrentVolume = tempVolume;
        }
    }
}