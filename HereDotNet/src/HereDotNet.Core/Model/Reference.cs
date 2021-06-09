using System.Collections.Generic;


namespace HereDotNet.Core.Model
{
    public class Reference
    {
        public string Id { get; set; }
        public List<Supplier> Supplier { get; set; }
    }

    public class Supplier
    {
        public SupplierType Id { get; set; }
    }

    public enum SupplierType
    {
        core, yelp, tripadvisor, parkopedia
    }
}
