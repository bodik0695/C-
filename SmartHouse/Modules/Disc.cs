using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Disc : IDisc
    {
        public string Name { get; set; }
        public int NumberOfTracks { get; set; }
        public string[] Tracks { get; set; }

        public Disc(string name, string[] tracks)
        {
            Name = name;
            Tracks = tracks;
            NumberOfTracks = Tracks.Length;
        }
    }
}