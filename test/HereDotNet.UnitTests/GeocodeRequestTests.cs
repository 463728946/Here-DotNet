using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Services;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace HereDotNet.UnitTests
{
    using static TestFixture;
    public class GeocodeRequestTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public async Task GeocodeRequest_ShouldBeTrue()
        {
            var apikey = GetKeyApi();
            var cfg = new HereConfiguration();
            cfg.UseApiKey(apikey);

            var svr = new SearchService(cfg);
            var result = await svr.SearchAsync(new GeocodeRequest()
            {
                Q = "158 28nd Street San Francisco California US 91754"
            });

            result.IsSuccessful.ShouldBeTrue();
            //result.Data.Items.Any(x => x.Contains("is required, but not found")).ShouldBeTrue();
        }
    }
}