using System.Collections.Generic;

namespace HereDotNet.Core.Model
{
    public class Scoring
    {
        public double QueryScore { get; set; }
        public FieldScore FieldScore { get; set; }
    }

    public class FieldScore
    {
        public double Country { get; set; }
        public double CountryCode { get; set; }
        public double State { get; set; }
        public double StateCode { get; set; }
        public double County { get; set; }
        public double CountyCode { get; set; }
        public double City { get; set; }
        public double District { get; set; }
        public double SubDistrict { get; set; }
        public IEnumerable<double> Streets { get; set; }
        public double Block { get; set; }
        public double SubBlock { get; set; }
        public double HouseNumber { get; set; }
        public double PostalCode { get; set; }
        public double Building { get; set; }
        public double Unit { get; set; }
        public double PlaceName { get; set; }
        public double OntologyName { get; set; }
    }
}