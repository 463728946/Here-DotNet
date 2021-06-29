using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Model
{
    public class AccessTime
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override string ToString()
        {
            return $"{Start.ToString("ddd").Remove(2, 1).ToLower()}{Start:HH:mm:sszzzz}|{End.ToString("ddd").Remove(2, 1).ToLower()}{End:HH:mm:sszzzz}";
        }
    }
}
