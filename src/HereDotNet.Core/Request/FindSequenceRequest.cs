﻿using HereDotNet.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace HereDotNet.Core.Request
{
    public class FindSequenceRequest : IRequest
    {
        public string Method => "GET";
        public string Endpoint => "/findsequence.json";
        public string Root => "wse.";



        [Description("departure")]
        public string Departure { get; }

        [Description("destination{0}")]
        public string[] DestinationN { get; }

        [Description("mode")]
        public string Mode { get; }

        [Description("start")]
        public string Start { get; }


        //--------------------

        [Description("avoidLinks")]
        public string AvoidLinks { get; set; }

        [Description("avoidArea")]
        public string AvoidArea { get; set; }

        [Description("end")]
        public string End { get; set; }

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


        public FindSequenceRequest(DateTime departure, List<Waypoint> destinations, Coordinates start, ModeType type = ModeType.fastest, Transport_mode tran = Transport_mode.car, bool traffic = false)
        {
            Mode = $"{type};{tran};traffic:{ (traffic ? "enabled" : "disabled")}";
            Start = start.ToString();
            Departure = departure.ToString("yyyy-MM-ddThh:mm:sszzzz");

            DestinationN = new string[destinations.Count];
            for (int i = 0; i < destinations.Count; i++)
                DestinationN[i] = destinations[i].ToString();


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