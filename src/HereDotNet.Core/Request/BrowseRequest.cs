using System;
using System.Collections.Generic;

namespace HereDotNet.Core.Request
{
    public class BrowseRequest : IRequest
    {
        public string Method => throw new NotImplementedException();

        public string Endpoint => throw new NotImplementedException();

        public string Root => throw new NotImplementedException();

        public Dictionary<string, object> ToParameter()
        {
            throw new NotImplementedException();
        }
    }
}
