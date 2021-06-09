

namespace HereDotNet.Core.Request
{
    public interface IRequest
    {
        string Method { get; }
        string Endpoint { get; }
        string Root { get; }
    }
}
