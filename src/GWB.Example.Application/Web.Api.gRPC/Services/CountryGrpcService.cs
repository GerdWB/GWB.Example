namespace GWB.Example.Web.Api.gRPC.Services;

using Application.Core.Queries;
using Application.Core.Results;
using AutoMapper;
using Example.gRPC;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ProtoBuf.Mappings;
using static Example.gRPC.CountryService;

public class CountryGrpcService : CountryServiceBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public CountryGrpcService(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    //public override Task<CountryCreationReply> Create(CountryCreationRequest request, ServerCallContext context)
    //    => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    //public override Task<Empty> Delete(CountryIdRequest request, ServerCallContext context)
    //    => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    //public override async Task<CountryReply> Get(
    //    CountryIdRequest request,
    //    ServerCallContext context)
    //    => throw new RpcException(new Status(StatusCode.Unimplemented, ""));


    public override async Task<CountryListReply> GetAll(Empty request, ServerCallContext context)
    {
        var query = new Countries.GetAll.Query();
        var queryResult = await _sender.Send(query, context.CancellationToken);

        queryResult.OnSuccess(
                success => success.Value.ToProto())
            .OnFailure(
                failure => throw new RpcException(new Status(StatusCode.Unknown, failure.Reason)));

        throw new RpcException(new Status(StatusCode.Unknown, "Unknown Query Result"));
    }

    //public override async Task<Empty> Update(
    //    CountryUpdateRequest request,
    //    ServerCallContext context)
    //    => throw new RpcException(new Status(StatusCode.Unimplemented, ""));
}