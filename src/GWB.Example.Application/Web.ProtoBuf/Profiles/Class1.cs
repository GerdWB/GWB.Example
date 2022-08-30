namespace GWB.Example.Web.ProtoBuf.Profiles;

using Application.Core.Domain.Entities;
using AutoMapper;
using gRPC;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryReply>();
    }
}