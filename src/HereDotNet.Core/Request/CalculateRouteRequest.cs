using HereDotNet.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace HereDotNet.Core.Request
{
    //https://router.hereapi.com/v8/routes
    //https://developer.here.com/documentation/routing-api/api-reference-swagger.html
    public class CalculateRouteRequest : IRequest
    {
        public string Method => "GET";

        public string Endpoint => "/routes";

        public string Root => "";

        public Transport_mode Transportmode { get; set; }//required        
        public Coordinates Origin { get; set; } //required 起始地
        public Coordinates Destination { get; set; } //required 目的地

        public List<Coordinates> Via { get; set; }

        [Description("departureTime|yyyy-MM-ddThh:mm:sszzzz")]
        public DateTime DepartureTime { get; set; }
        //public string RoutingMode { get; set; } 

        //public int Alternatives { get; set; }
       
        //public string Units { get; set; }

        public List<string> Return { get; set; }

    }

    public enum Return
    {
        polyline, actions, instructions, summary ,travelSummary, mlDuration, typicalDuration ,turnByTurnActions ,elevation ,routeHandle, passthrough ,incidents, routingZones, tolls
    }


}
