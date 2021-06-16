using HereDotNet.Core.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace HereDotNet.Core.Request
{
    public class GeocodeRequest : IRequest
    {
        string IRequest.Method => "GET";

        string IRequest.Endpoint => "/geocode";

        string IRequest.Root => "geocode.";

        [Description("at")]
        public Coordinates At { get; set; }

        [Description("in")]
        public Coordinates In { get; set; }

        [Description("limit")]
        public int? Limit { get; set; }

        [Description("q")]
        public string Q { get; set; }

        [Description("qq")]
        public string QQ { get; set; }

        [Description("lang")]
        public string[] Lang { get; set; }

        [Description("politicalView")]
        public string PoliticalView { get; set; }

        [Description("show")]
        public string[] Show { get; set; }

    }
}
