using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class TV : Device
    {
        public Sound Sound { get; set; }
        public Channel Channel { get; set; }

        protected TV() { }
        public TV(bool power, Sound vol, Channel chan)
        {
            Power = power;
            Sound = vol;
            Channel = chan;
        }

        public override void Off()
        {
            Power = false;
        }

        public override void On()
        {
            Power = true;
        }

        public virtual void DecreaseSound()
        {
            Sound.DecreaseSound();
        }

        public virtual void IncreaseSound()
        {
            Sound.IncreaseSound();
        }

        public virtual void NextChannel()
        {
            Channel.NextChannel();
        }

        public virtual void PreviousChannel()
        {
            Channel.PreviousChannel();
        }

        public virtual void SelectChannel(int channelNumber)
        {
            Channel.SelectChannel(channelNumber);
        }

        public virtual void SoundOff()
        {
            Sound.SoundOff();
        }

        public virtual void SoundOn()
        {
            Sound.SoundOn();
        }
    }
}