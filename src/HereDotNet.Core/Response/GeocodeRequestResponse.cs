using HereDotNet.Core.Model;
using System.Collections.Generic;


namespace HereDotNet.Core.Response
{

   
    public class GeocodeRequestResponse 
    {       
        public IList<GeocodeResponseItem> Items { get; set; }
    }
   

    public class GeocodeResponseItem
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string PoliticalView { get; set; }
       
        public ResultType? ResultType { get; set; }
        public HouseNumberType? HouseNumberType { get; set; }
        public AddressBlockType? AddressBlockType { get; set; }
        public LocalityType? LocalityType { get; set; }
        public AdministrativeAreaType? AdministrativeAreaType { get; set; }

        public Address Address { get; set; }
        public Coordinates Position { get; set; }
        public List<Coordinates> Access { get; set; }
        public long Distance { get; set; }
        public MapView MapView { get; set; }
        public List<Category> Categories { get; set; }
       
        public IList<Category> FoodTypes { get; set; }

        public bool HouseNumberFallback { get; set; }
       
        public object TimeZone { get; set; }

        public object Extended { get; set; }

        public object Phonemes { get; set; }
    }

}
