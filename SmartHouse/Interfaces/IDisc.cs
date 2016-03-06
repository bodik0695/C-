using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IDisc
    {
        string Name { get; set; }
        int NumberOfTracks { get; set; }
        string[] Tracks { get; set; }
    }
}