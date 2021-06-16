

using System.Collections.Generic;

namespace HereDotNet.Core.Request
{
    internal interface IRequest
    {
        internal string Method => "";
        internal string Endpoint=> "";
        internal string Root => "";
    }
}
