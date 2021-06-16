using HereDotNet.Core.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace HereDotNet.Core.Request
{
    public class GeocodeRequest : IRequest
    {
        internal string Method => "GET";
        internal string Endpoint => "/geocode";
        internal string Root => "geocode.";


        [Description("at")]
        public string At { get; }

        [Description("in")]
        public string In { get; }

        [Description("limit")]
        public int? Limit { get; }

        [Description("q")]
        public string Q { get; }

        [Description("qq")]
        public string QQ { get; }

        [Description("lang")]
        public string[] Lang { get; }

        [Description("politicalView")]
        public string PoliticalView { get; }

        [Description("show")]
        public string[] Show { get; }



        public GeocodeRequest(string q)
        {
            if (!string.IsNullOrEmpty(q)) Q = q;
        }


        public GeocodeRequest(string q = null, Coordinates at = null, string _in = null, int? limit = 20, string qq = null, string[] lang = null, string politicalView = null, string[] show = null) : this(q)
        {
            At = at?.ToString();
            In = _in;
            Limit = limit;
            QQ = qq;
            Lang = lang;
            PoliticalView = politicalView;
            Show = show;

        }
       
    }
}
