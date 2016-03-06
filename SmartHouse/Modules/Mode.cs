using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class Mode : IMode
    {
        public UniversalMode CurrentMode { get; set; }
    }
}