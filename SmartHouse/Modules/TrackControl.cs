using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class TrackControl : ITrackControl
    {
        public int CurrentTrack { get; set; }
        public int NumberOfTrack { get; set; }
        public string[] Tracks { get; set; }
        public string CurrentDiskName { get; set; }
        public string CurrentTrackName { get; set; }

        protected TrackControl() { }
        public TrackControl(int currentTrack)
        {
                CurrentTrack = currentTrack;
        }

        public virtual void NextTrack()
        {
            if (CurrentTrack > 0 && CurrentTrack < NumberOfTrack)
            {
                CurrentTrack++;
                CurrentTrackName = Tracks[CurrentTrack - 1];
            }
        }

        public virtual void PreviousTrack()
        {
            if (CurrentTrack > 1 && CurrentTrack <= NumberOfTrack)
            {
                CurrentTrack--;
                CurrentTrackName = Tracks[CurrentTrack - 1];
            }
        }

        public virtual bool SelectTrack(string trackName)
        {
            int temp = 0;
            bool b = false;
               for(int i = 0; i <= Tracks.Length; i++)
            {
                if (Tracks[i] == trackName)
                {
                    CurrentTrack = i+1;
                    CurrentTrackName = Tracks[i];
                    b = true;
                    break;
                }
                temp++;
            }      
            return b;
        }
    }
}