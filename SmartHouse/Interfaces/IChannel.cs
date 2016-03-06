using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IChannel
    {
        int CurrentChannel { get; set; }
        void SelectChannel(int channelNumber);
        void NextChannel();
        void PreviousChannel();
    }
}