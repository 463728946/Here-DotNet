using HereDotNet.Core.Configuration;
using HereDotNet.Core.Model;
using HereDotNet.Core.Request;
using HereDotNet.Core.Services;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HereDotNet.UnitTests
{
    public class ModelTest
    {
        [Test]
        public void AccessTime()
        {
            var acc = new AccessTime { Start = new DateTime(2021, 06, 29, 10, 00, 00), End = new DateTime(2021, 06, 29, 12, 00, 00) };
            acc.ToString().ShouldBe($"tu10:00:00{ DateTime.Now:zzzz}|tu12:00:00{ DateTime.Now:zzzz}");                    
        }

        [Test]
        public void Waypoint()
        {
            var accessTimes = new List<AccessTime>();
            accessTimes.Add(new AccessTime { Start = new DateTime(2021, 06, 29, 10, 00, 00), End = new DateTime(2021, 06, 29, 12, 00, 00) });
            accessTimes.Add(new AccessTime { Start = new DateTime(2021, 06, 29, 14, 00, 00), End = new DateTime(2021, 06, 29, 16, 00, 00) });
            var waypoint = new Waypoint(11, 11, 600, new DateTime(2021, 06, 29, 10, 00, 00), accessTimes);
            waypoint.ToString().ShouldBe($"11,11;st:600;at:2021-06-29T10:00:00{ DateTime.Now:zzzz};acc:tu10:00:00{ DateTime.Now:zzzz}|tu12:00:00{ DateTime.Now:zzzz},tu14:00:00{ DateTime.Now:zzzz}|tu16:00:00{ DateTime.Now:zzzz};");
        }
    }
}
