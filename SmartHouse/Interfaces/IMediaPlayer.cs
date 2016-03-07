using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IMediaPlayer : IDevice
    {
        Sound Sound { get; set; }
        TrackControl TrackControl { get; set; }
        Mode Mode { get; set; }
        bool DiscPresence { get; set; }

        void DecreaseSound();
        void IncreaseSound();
        void NextTrack();
        void PreviousTrack();
        void Pause();
        void Play();
        void Stop();
        bool SelectTrack(string trackName);
        void SoundOff();
        void SoundOn();
        void InsertDisc(Disc d);
        void ExtractDisc();
        string ToString();
    }
}