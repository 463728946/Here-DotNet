using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;

namespace HereDotNet.UnitTests
{
    [SetUpFixture]
    public class TestFixture
    {
        public static string GetKeyApi()
        {           
            var root = new ConfigurationBuilder()              
              .AddJsonFile("appsettings.json", true, true)
              .AddEnvironmentVariables()
              .Build();


            return root.GetValue<string>("Here:apikey");
        }
    }
}
