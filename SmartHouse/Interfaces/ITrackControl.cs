using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface ITrackControl
    {
        int CurrentTrack { get; set; }
        bool SelectTrack(string trackName);
        void NextTrack();
        void PreviousTrack();
    }
}