using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Model
{
    public class Contact
    {
        public IList<LabelValue> Phone { get; set; }
        public IList<LabelValue> Mobile { get; set; }
        public IList<LabelValue> TollFree { get; set; }
        public IList<LabelValue> Fax { get; set; }
        public IList<LabelValue> www { get; set; }
        public IList<LabelValue> Email { get; set; }
    }
}
