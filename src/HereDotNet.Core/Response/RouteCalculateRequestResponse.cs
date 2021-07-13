using HereDotNet.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Response
{
    public class RouteCalculateRequestResponse
    {
        public List<Route> Routes { get; set; }
    }

    public class Route
    {
        public Guid Id { get; set; }
        public List<Section> Sections { get; set; }

    }

    public class Section
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
        public Summary Summary { get; set; }
        public Transport Transport { get; set; }
    }

    public class Summary
    {
        public double Duration { get; set; }
        public double Length { get; set; }
        public double BaseDuration { get; set; }
    }

    public class Place
    {
        public string Type { get; set; }
        public Coordinates Location { get; set; }
        public Coordinates OriginalLocation { get; set; }
    }
    
    public class Departure
    {
        public  DateTime Time { get; set; }
        public  Place Place { get; set; }
    }

   

    public class Arrival: Departure
    {
        
    }

    public class Transport
    {
        public string Mode { get; set; }
    }

}
