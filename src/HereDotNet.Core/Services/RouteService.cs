using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Response;
using System.Threading.Tasks;

namespace HereDotNet.Core.Services
{
    public interface IRouteService
    {
        Task<IResponse<RouteCalculateRequestResponse>> RouteCalculateAsync(CalculateRouteRequest request);
    }


    public class RouteService : BaseService, IRouteService
    {
        public RouteService(HereConfiguration hereConfiguration, string name = "router", string version = "/v8") : base(hereConfiguration, name, version) {}

        public async Task<IResponse<RouteCalculateRequestResponse>> RouteCalculateAsync(CalculateRouteRequest hereRequest)
             => await HandleAsync<CalculateRouteRequest, RouteCalculateRequestResponse>(hereRequest);

    }

}
