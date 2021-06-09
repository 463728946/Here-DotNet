using HereDotNet.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Response
{
    public class FindSequenceRequestResponse
    {
        public IList<string> Errors { get; set; }
        public string ProcessingTimeDesc { get; set; }
        public string RequestId { get; set; }
        public string ResponseCode { get; set; }
        public List<FindSequenceRequestItemResponse> Results { get; set; }
        public List<WarningItem> Warnings { get; set; }

    }

    public class FindSequenceRequestItemResponse
    {
        public string Description { get; set; }
        public int Distance { get; set; }
        public IList<Interconnection> Interconnections { get; set; }
        public long Time { get; set; }
        public TimeBreakdown TimeBreakdown { get; set; }
        public List<WaypointSequence> Waypoints { get; set; }
    }

    public class WaypointSequence : Coordinates
    {
        public string Id { get; set; }
        public int Sequence { get; set; }
        public DateTime EstimatedArrival { get; set; }
        public DateTime EstimatedDeparture { get; set; }
        public List<string> FulfilledConstraints { get; set; }
        public WaypointSequence() : base()
        {

        }
    }

    public class Interconnection
    {
        public string FromWaypoint { get; set; }
        public string ToWaypoint { get; set; }
        public string Time { get; set; }
        public string Distance { get; set; }
        public string Rest { get; set; }
        public string Waiting { get; set; }
    }

    public class TimeBreakdown
    {
        public int Driving { get; set; }
        public int Service { get; set; }
        public int Rest { get; set; }
        public int Waiting { get; set; }
    }

    public class WarningItem : Coordinates
    {
        public string Id { get; set; }
        public List<FailedConstraint> FailedConstraints { get; set; }
        public WarningItem(double latitude, double longitude) : base(latitude, longitude)
        {

        }
    }

    public class FailedConstraint
    {
        public string Constraint { get; set; }
        public string Reason { get; set; }
    }

}
