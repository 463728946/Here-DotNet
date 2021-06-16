

using System.Collections.Generic;

namespace HereDotNet.Core.Request
{
    internal interface IRequest
    {
        string Method { get; }
        string Endpoint { get; }
        string Root { get; }
    }
}
