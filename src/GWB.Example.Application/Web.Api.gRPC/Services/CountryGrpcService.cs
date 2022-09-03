namespace GWB.Example.Web.Api.gRPC.Services;

using Application.Core.Queries;
using Example.gRPC;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GWB.Example.Web.Api.gRPC.ErrorHandling;
using GWB.Example.Web.ProtoBuf.Mappings;
using MediatR;
using static Example.gRPC.CountryService;

public class CountryGrpcService : CountryServiceBase
{
    private readonly ISender _sender;

    public CountryGrpcService(ISender sender)
    {
        _sender = sender;
    }

    public override Task<CountryCreationReply> Create(CountryCreationRequest request, ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    public override Task<Empty> Delete(CountryIdRequest request, ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    public override async Task<CountryReply> Get(
        CountryIdRequest request,
        ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));


    public override async Task<CountryListReply> GetAll(Empty request, ServerCallContext context)
    {
        var query = new Countries.GetAll.Query();
        var queryResult = await _sender.Send(query, context.CancellationToken);
        return queryResult.HandleResult().ToProto();
    }

    public override async Task<Empty> Update(
        CountryUpdateRequest request,
        ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));
}