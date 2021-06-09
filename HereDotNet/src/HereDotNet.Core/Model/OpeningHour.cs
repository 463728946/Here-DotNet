using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Model
{
    public class OpeningHour
    {
        public List<string> Text { get; set; }
        public bool IsOpen { get; set; }
        public IList<Structured> Structured { get; set; }
    }
}
