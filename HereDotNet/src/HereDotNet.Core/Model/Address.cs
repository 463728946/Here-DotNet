using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Core.Model
{
    public class Address
    {
        public string Label { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string StateCode { get; set; }
        public string State { get; set; }
        public string CountyCode { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Subdistrict { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string Subblock { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
    }
}
