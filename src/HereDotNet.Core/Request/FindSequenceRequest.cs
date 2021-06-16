using HereDotNet.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HereDotNet.Core.Request
{
    public class FindSequenceRequest : IRequest
    {       
        string IRequest.Method => "GET";
        string IRequest.Endpoint => "/findsequence.json";
        string IRequest.Root => "wse.";


        [Description("departure|yyyy-MM-ddThh:mm:sszzzz")]
        public DateTime Departure { get; set; }

        [Description("destination{0}")]
        public List<Waypoint> DestinationN { get; set; }

        [Description("mode")]
        public Mode Mode { get; set; }

        [Description("start")]
        public Coordinates Start { get; set; }


        //--------------------

        [Description("avoidLinks")]
        public string AvoidLinks { get; set; }

        [Description("avoidArea")]
        public string AvoidArea { get; set; }

        [Description("end")]
        public Coordinates End { get; set; }

        [Description("hasTrailer")]
        public string HasTrailer { get; set; }

        [Description("height")]
        public string Height { get; set; }

        [Description("improveFor")]
        public string ImproveFor { get; set; }

        [Description("jsonCallback")]
        public string JsonCallback { get; set; }

        [Description("length")]
        public string Length { get; set; }

        [Description("limitedWeight")]
        public string LimitedWeight { get; set; }

        [Description("requestId")]
        public string RequestId { get; set; }

        [Description("restTimes")]
        public string RestTimes { get; set; }

        [Description("shippedHazardousGoods")]
        public string ShippedHazardousGoods { get; set; }

        [Description("tunnelCategory")]
        public string TunnelCategory { get; set; }

        [Description("walkSpeed")]
        public string WalkSpeed { get; set; }

        [Description("weightPerAxle")]
        public string WeightPerAxle { get; set; }

        [Description("width")]
        public string Width { get; set; }

       

        public FindSequenceRequest()
        {
            //DateTime departure, List<Waypoint> destinations, Coordinates start, ModeType type = ModeType.fastest, Transport_mode tran = Transport_mode.car, bool traffic = false
            //Mode = $"{type};{tran};traffic:{ (traffic ? "enabled" : "disabled")}";
            //Start = start.ToString();
            //Departure = departure.ToString("yyyy-MM-ddThh:mm:sszzzz");

            //DestinationN = new string[destinations.Count];
            //for (int i = 0; i < destinations.Count; i++)
            //    DestinationN[i] = destinations[i].ToString();
            //Departure = departure;
            //DestinationN = destinations;
            //Start = start;
            //Mode = new Mode { Type = type, Transport_mode = tran, Traffic = traffic };                                   
        }
        
    }

    public struct Mode
    {
        public ModeType Type { get; set; }
        public Transport_mode Transport_mode { get; set; }
        public bool Traffic { get; set; }

        public override string ToString()
        {
            return $"{Type};{Transport_mode};traffic:{ (Traffic ? "enabled" : "disabled")}";
        }
    }


    public enum ModeType
    {
        fastest, shortest
    }
    public enum Transport_mode
    {
        car, truck, pedestrian
    }

}
