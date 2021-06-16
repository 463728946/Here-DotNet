using System;
using System.Collections.Generic;

namespace HereDotNet.Core.Request
{
    public class BrowseRequest : IRequest
    {
        string IRequest.Method => "";

        string IRequest.Endpoint => "";

        string IRequest.Root => "";
    }
}
