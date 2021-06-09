using System.Net;


namespace HereDotNet.Core.Response
{
    public interface IResponse<T>
    {
        bool IsSuccessful { get; set; }
        string Status { get; set; }
        HttpStatusCode StatusCode { get; set; }
        string ErrorMessage { get; set; }
        T Data { get; set; }
    }

    public enum ResultType
    {
        AdministrativeArea,
        Locality,
        street,
        intersection,
        addressBlock,
        houseNumber,
        postalCodePoint,
        place
    }

    public enum HouseNumberType
    {
        PA,
        Interpolated
    }

    public enum AddressBlockType
    {
        Block,
        Subblock
    }

    public enum LocalityType
    {
        PostalCode,
        Subdistrict,
        District,
        City
    }
    public enum AdministrativeAreaType
    {
        County,
        State,
        Country
    }
}
