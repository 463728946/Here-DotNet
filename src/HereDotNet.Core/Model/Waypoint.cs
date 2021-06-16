﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Model
{



    public class Waypoint //: Coordinates
    {
        public readonly string Id;
        public readonly Coordinates Coordinates;
        public readonly int? St;
        public readonly DateTime? At;
        public readonly List<DateTime> Acc;
        public readonly string Before;
        public readonly string Pickup;
        public readonly string Drop;


        public Waypoint(double latitude, double longitude, int? st = null, DateTime? at = null, List<DateTime> acc = null, string before = "", string pickup = "", string dorp = "", string id = "")// : base(latitude, longitude)
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
            if (At.HasValue) str.Append($"at:{ At.Value:yyyy-MM-ddThh:mm:sszzz};");
            //if (Acc.HasValue) str.Append($"acc:{Acc.Value.ToString("ddd").Remove(2, 1).ToLower()}{Acc.Value:hh:mm:sszzzz};");
            if (Acc != null && Acc.Count > 0)
            {
                var acc = "";
                foreach (var item in Acc)
                {
                    acc = string.IsNullOrEmpty(acc) ? $"{item.ToString("ddd").Remove(2, 1).ToLower()}{item:hh:mm:sszzzz}" : $"{acc}|{item.ToString("ddd").Remove(2, 1).ToLower()}{item:hh:mm:sszzzz}";
                }
                str.Append($"acc:{acc};");
            }
            if (!string.IsNullOrEmpty(Before)) str.Append($"before:{Before};");
            if (!string.IsNullOrEmpty(Drop)) str.Append($"drop:{Drop};");

            return str.ToString();
        }

        //public Waypoint(
        //    GeoCoordinates coordinates,
        //    WaypointType? waypointType,
        //    int transitRadiusInMeters = 0,
        //    int durationInSeconds = 0,
        //    double? headingInDegrees = null,
        //    GeoCoordinates sideOfStreetHint = null,
        //    int? minCourseDistanceInMeters = null)
        //{
        //    Coordinates = coordinates;
        //}
    }

    public enum WaypointType
    {
        passThrough, stopover, values
    }
}
