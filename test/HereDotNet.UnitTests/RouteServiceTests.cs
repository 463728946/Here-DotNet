using HereDotNet.Core.Configuration;
using HereDotNet.Core.Model;
using HereDotNet.Core.Request;
using HereDotNet.Core.Services;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HereDotNet.UnitTests
{
    using static TestFixture;
    public class RouteServiceTests
    {
        [Test]
        public async Task RouteCalculate_NoApiKey_Unauthorized()
        {
            var cfg = new HereConfiguration();
            cfg.UseApiKey("<Your ApiKey>");

            var svr = new RouteService(cfg);
            var result = await svr.RouteCalculateAsync(new CalculateRouteRequest()
            {
                Transportmode = Transport_mode.car,
                Origin = new Coordinates(33.98269305, -118.1723896),
                Destination = new Coordinates(33.98269305, -118.1723896),
                DepartureTime = DateTime.Now.AddDays(1)

            }); ;

            result.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
        }

        [Test]
        public async Task RouteCalculate_ShouldBeTrue()
        {
            var cfg = new HereConfiguration();
            cfg.UseApiKey("UXm9sZ9IOd_z3_7puoz2oc7TgxGryOH7LUEuKRxbTYU");

            var svr = new RouteService(cfg);
            var result = await svr.RouteCalculateAsync(new CalculateRouteRequest()
            {
                Transportmode = Transport_mode.car,
                Origin = new Coordinates(33.98269305, -118.1723896),
                Destination = new Coordinates(33.98269305, -118.1723896),
                DepartureTime = DateTime.Now.AddDays(1)

            });

            result.StatusCode.ShouldBe(HttpStatusCode.OK);
            Console.WriteLine(result.Data.Routes.Count);
        }
    }
}
