using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Channel : IChannel
    {
        public int CurrentChannel { get; set; }
        public int MaxChannelNumber { get; set; }
        public int MinChannelNumber { get; set; }

        protected Channel() { }
        public Channel(int currentChannel, int minChannelNumber, int maxChannelNumber)
        {
            if (currentChannel >= MinChannelNumber && currentChannel <= maxChannelNumber)
            {
                CurrentChannel = currentChannel;
            }
            if (minChannelNumber > 0)
            {
                MinChannelNumber = minChannelNumber;
            }
            if (maxChannelNumber > minChannelNumber)
            {
                MaxChannelNumber = maxChannelNumber;
            }
        }
        public virtual void NextChannel()
        {
            if (CurrentChannel >= MinChannelNumber && CurrentChannel < MaxChannelNumber)
            {
                CurrentChannel++;
            }
        }

        public virtual void PreviousChannel()
        {
            if (CurrentChannel > MinChannelNumber && CurrentChannel <= MaxChannelNumber)
            {
                CurrentChannel--;
            }
        }

        public virtual void SelectChannel(int channelNumber)
        {
            if(channelNumber >= MinChannelNumber && channelNumber <= MaxChannelNumber)
            {
                CurrentChannel = channelNumber;
            }
        }
    }
}