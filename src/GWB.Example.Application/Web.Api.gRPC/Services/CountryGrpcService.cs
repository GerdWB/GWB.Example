namespace CountryService.Web.Services;

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GWB.Example.gRPC;
using static GWB.Example.gRPC.CountryService;

public class CountryGrpcService : CountryServiceBase
{
    public override async Task Create(
        IAsyncStreamReader<CountryCreationRequest> requestStream,
        IServerStreamWriter<CountryCreationReply> responseStream,
        ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    public override async Task<Empty> Delete(
        IAsyncStreamReader<CountryIdRequest> requestStream,
        ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    public override async Task<CountryReply> Get(
        CountryIdRequest request,
        ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    public override async Task GetAll(
        Empty request,
        IServerStreamWriter<CountryReply> responseStream,
        ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));

    public override async Task<Empty> Update(
        CountryUpdateRequest request,
        ServerCallContext context)
        => throw new RpcException(new Status(StatusCode.Unimplemented, ""));
}