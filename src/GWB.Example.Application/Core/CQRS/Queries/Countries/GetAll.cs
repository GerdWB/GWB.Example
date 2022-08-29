namespace GWB.Example.Application.Core.Queries;

using Domain;
using GWB.Example.Application.Core.Abstractions;
using MediatR;
using Results;
using Services;

public static partial class Countries
{
    public static class GetAll
    {
        public record Query : IQuery<IEnumerable<Country>>; 

        public class Handler : IQueryHandler<Query, IEnumerable<Country>>
        {
            private readonly ICountryQueryService _countryQueryService;

            public Handler(ICountryQueryService templateTreeReadOnlyService) =>
                _countryQueryService = templateTreeReadOnlyService;

            public Task<QueryResult<IEnumerable<Country>>> Handle(Query request, CancellationToken cancellationToken) =>
                _countryQueryService.GetAllAsync();
        }
    }
}