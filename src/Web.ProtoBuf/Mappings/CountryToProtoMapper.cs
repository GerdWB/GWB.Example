namespace GWB.Example.Web.ProtoBuf.Mappings;

using Application.Core.Domain.Entities;
using gRPC;

public static class CountryToProtoMapper
{
    public static CountryReply ToProto(this Country country)
    {
        var protoUser = new CountryReply
        {
            Id = country.Id.ToProtoString(),
            Name = country.Name.ToProtoString(),
            Description = country.Description.ToProtoString(),
            Flag = country.FlagImage.ToProtoBytes(),
            CreateDate = country.Created.ToProtoDateString(),
            UpdateDate = country.Updated.ToProtoDateString()
        };

        return protoUser;
    }

    public static CountryListReply ToProto(this IEnumerable<Country> countries)
    {
        var countryListReply = new CountryListReply();
        foreach (var country in countries)
        {
            countryListReply.Countries.Add(country.ToProto());
        }

        return countryListReply;
    }
}