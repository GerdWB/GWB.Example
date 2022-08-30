// ReSharper disable UnusedMember.Global

namespace GWB.Example.Application.Core.Queries;

using Domain.Entities;
using MediatR;
using Results;
using Services;

public static partial class Countries
{
    public static class GetById
    {
        public record Query(Guid CountryId) : IRequest<QueryResult<Country>>;

        public class Handler : IRequestHandler<Query, QueryResult<Country>>
        {
            private readonly ICountryQueryService _countryQueryService;

            public Handler(ICountryQueryService templateTreeReadOnlyService) =>
                _countryQueryService = templateTreeReadOnlyService;

            public Task<QueryResult<Country>> Handle(Query request, CancellationToken cancellationToken) =>
                _countryQueryService.GetByIdAsync(request.CountryId);
        }
    }
}