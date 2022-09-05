namespace GWB.Example.Web.ProtoBuf.Mappings;

using Application.Core.Domain.Entities;
using gRPC;

public static class CountryFromProtoMapper
{
    public static IEnumerable<Country> FromProto(this CountryListReply countryListReply)
        => countryListReply.Countries.Select(x => x.FromProto());


    public static Country FromProto(this CountryReply countryReply) =>
        new(
            countryReply.Id.ProtoStringToGuid(),
            countryReply.Name,
            countryReply.Description,
            countryReply.Flag.ToByteArray(),
            countryReply.CreateDate.ProtoStringToDateTime(),
            countryReply.UpdateDate.ProtoStringToNullableDateTime()
        );
}