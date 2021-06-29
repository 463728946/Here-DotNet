using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core
{
    public interface IHereConfigurationBuilder
    {
        IHereConfigurationBuilder AddRouteService(string name = "router", string version = "/v8");
        IHereConfigurationBuilder AddSearchService(string name = "search.", string version = "/v1");
        IHereConfigurationBuilder AddWaypointsSequenceExtensionService(string name = "ls.", string version = "/2");

        IHereConfigurationBuilder UseApiKey(string apikey);
        IHereConfigurationBuilder UseJwt(string token);
        IHereConfigurationBuilder UseUserPassword(string user, string password);
    }
}
