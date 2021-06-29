using HereDotNet.Core.Configuration;
using HereDotNet.Core.Request;
using HereDotNet.Core.Response;
using System.Threading.Tasks;

namespace HereDotNet.Core.Services
{
    public interface IWaypointsSequenceExtensionService
    {
        Task<IResponse<FindSequenceRequestResponse>> FindsequenceAsync(FindSequenceRequest request);
    }
    public class WaypointsSequenceExtensionService : BaseService, IWaypointsSequenceExtensionService
    {
        public WaypointsSequenceExtensionService(HereConfiguration hereConfiguration, string name = "ls.", string version = "/2") : base(hereConfiguration, name, version) { }

        public async Task<IResponse<FindSequenceRequestResponse>> FindsequenceAsync(FindSequenceRequest hereRequest)
             => await HandleAsync<FindSequenceRequest, FindSequenceRequestResponse>(hereRequest);

    }
}
