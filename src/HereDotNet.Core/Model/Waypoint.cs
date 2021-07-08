using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Model
{
    public class Waypoint //: Coordinates
    {
        public readonly Coordinates Coordinates;
        public  int? St{ get; set; }
        public  DateTime? At{ get; set; }
        public  List<AccessTime> Acc{ get; set; }
        public  string Before { get; set; }
        public  string Pickup{ get; set; }
        public  string Drop{ get; set; }
        public  string Id{ get; set; }

        public Waypoint(double latitude, double longitude, int? st = null, DateTime? at = null, List<AccessTime> acc = null, string before = "", string pickup = "", string dorp = "", string id = "")// : base(latitude, longitude)
        {
            Id = id;
            Coordinates = new Coordinates(latitude, longitude);
            St = st;
            At = at;
            Acc = acc;
            Before = before;
            Pickup = pickup;
            Drop = dorp;
        }


        public override string ToString()
        {
            var str = new StringBuilder();
            if (!string.IsNullOrEmpty(Id)) str.Append($"{Id};");
            if (Coordinates != null) str.Append($"{Coordinates};");
            if (St.HasValue) str.Append($"st:{St};");
            if (At.HasValue) str.Append($"at:{ At.Value:yyyy-MM-ddTHH:mm:sszzz};");            
            if (Acc != null && Acc.Count > 0)
            {
                var acc = "";
                foreach (var tw in Acc)
                {                                      
                    acc = string.IsNullOrEmpty(acc) ? tw.ToString() : $"{acc},{tw}";
                }
                str.Append($"acc:{acc};");
            }
            if (!string.IsNullOrEmpty(Before)) str.Append($"before:{Before};");
            if (!string.IsNullOrEmpty(Pickup)) str.Append($"pickup:{Pickup}");
            if (!string.IsNullOrEmpty(Drop)) str.Append($"drop:{Drop};");

            return str.ToString();
        }
    }

    public enum WaypointType
    {
        passThrough, stopover, values
    }
}
