using HereDotNet.Core.Configuration;
using HereDotNet.Core.Model;
using HereDotNet.Core.Request;
using HereDotNet.Core.Services;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HereDotNet.UnitTests
{
    using static TestFixture;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Findsequence_NoApiKey_Unauthorized()
        {
            var cfg = new HereConfiguration();            
            cfg.UseApiKey("<Your ApiKey>");

            var svr = new WaypointsSequenceExtensionService(cfg);

            var waypoint1 = new Waypoint(33.99450952, -118.2264696, 1769, null, new List<DateTime> { new DateTime(2021, 06, 16, 07, 0, 0), new DateTime(2021, 06, 16, 14, 0, 0) });
            var waypoint2 = new Waypoint(33.99215051, -118.2256395, 647, null, new List<DateTime> { new DateTime(2021, 06, 16, 11, 0, 0), new DateTime(2021, 06, 16, 18, 0, 0) });

            var result = await svr.FindsequenceAsync(new FindSequenceRequest()
            {
                Departure = DateTime.UtcNow.AddDays(1),
                DestinationN = new List<Waypoint> { waypoint1, waypoint2 },
                Mode = new Mode { Type = ModeType.fastest, Transport_mode = Transport_mode.car, Traffic = false },
                Start = new Coordinates(33.98269305, -118.1723896)
            });

            result.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
        }


        [Test]
        public async Task Findsequence_NoRequiredParameter_ShouldBeTrue()
        {
            var apikey = GetKeyApi();
            var cfg = new HereConfiguration();
            cfg.UseApiKey(apikey);            

            var svr = new WaypointsSequenceExtensionService(cfg);

            var waypoint1 =  new Waypoint(33.99450952, -118.2264696, 1769, null, new List<DateTime> { new DateTime(2021, 06, 16, 07, 0, 0), new DateTime(2021, 06, 16, 14, 0, 0) });
            var waypoint2 = new Waypoint(33.99215051, -118.2256395, 647, null, new List<DateTime> { new DateTime(2021, 06, 16, 11, 0, 0), new DateTime(2021, 06, 16, 18, 0, 0) });

            var result = await svr.FindsequenceAsync(new FindSequenceRequest()
            {
                Departure = DateTime.UtcNow.AddDays(1),
                DestinationN = new List<Waypoint> { waypoint1, waypoint2 },
                Mode = new Mode { Type = ModeType.fastest, Transport_mode = Transport_mode.car, Traffic = false },
                //Start = new Coordinates(33.98269305, -118.1723896)
            });

            result.Data.Errors.Any(x => x.Contains("is required, but not found")).ShouldBeTrue();
        }

        [Test]
        public async Task Findsequence_OkParameter_NoRoute()
        {
            var apikey = GetKeyApi();
            var cfg = new HereConfiguration();
            cfg.UseApiKey(apikey);

            var svr = new WaypointsSequenceExtensionService(cfg);

            var waypoint1 = new Waypoint(33.99450952, -118.2264696, 1769, null, new List<DateTime> { new DateTime(2021, 06, 16, 07, 0, 0), new DateTime(2021, 06, 16, 14, 0, 0) });
            var waypoint2 = new Waypoint(33.99215051, -118.2256395, 647, null, new List<DateTime> { new DateTime(2021, 06, 16, 11, 0, 0), new DateTime(2021, 06, 16, 18, 0, 0) });

            var result = await svr.FindsequenceAsync(new FindSequenceRequest()
            {
                Departure = DateTime.UtcNow.AddDays(1),
                DestinationN = new List<Waypoint> { waypoint1, waypoint2 },
                Mode = new Mode { Type = ModeType.fastest, Transport_mode = Transport_mode.car, Traffic = false },
                Start = new Coordinates(0,0)
            });

            result.Data.Errors.Any(x => x.Contains("No route")).ShouldBe(true);
        }
    }
}