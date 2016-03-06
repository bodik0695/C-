using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class MediaPlayer : Device
    {
        public Sound Sound { get; set; }
        public TrackControl TrackControl { get; set; }
        public Mode Mode { get; set; }
        public bool DiscPresence { get; set; }

        protected MediaPlayer() { }
        public MediaPlayer(bool power, PlayerModes pm, bool discPresence, Sound sound, TrackControl trackControl, Mode mode)
        {
            Power = power;
            DiscPresence = discPresence;
            Sound = sound;
            TrackControl = trackControl;
            Mode = mode;
            Mode.CurrentMode = (UniversalMode)pm;
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

        public virtual void NextTrack()
        {
            TrackControl.NextTrack();
        }

        public virtual void PreviousTrack()
        {
            TrackControl.PreviousTrack();
        }

        public virtual void Pause()
        {
            Mode.CurrentMode = (UniversalMode)PlayerModes.pause;
        }
        public virtual void Play()
        {
            Mode.CurrentMode = (UniversalMode)PlayerModes.play;
        }

        public virtual void Stop()
        {
            Mode.CurrentMode = (UniversalMode)PlayerModes.stop;
        }

        public virtual bool SelectTrack(string trackName)
        {
            bool result = false;
            if (DiscPresence)
            {
                result = TrackControl.SelectTrack(trackName);
            }
            return result;
        }

        public virtual void SoundOff()
        {
            Sound.SoundOff();
        }

        public virtual void SoundOn()
        {
            Sound.SoundOn();
        }

        public virtual void InsertDisc(Disc d)
        {
            DiscPresence = true;
            TrackControl.CurrentDiskName = d.Name;
            TrackControl.Tracks = d.Tracks;
            TrackControl.NumberOfTrack = d.NumberOfTracks;
            TrackControl.CurrentTrackName = d.Tracks[TrackControl.CurrentTrack - 1]; 

        }

        public virtual void ExtractDisc()
        {
            DiscPresence = false;
            TrackControl.NumberOfTrack = 0;
            string[] s = new string[0];
            TrackControl.Tracks = s;
            TrackControl.CurrentTrackName = "";
        }
    }
}