namespace GWB.Example.Application.Core.Abstractions;

using MediatR;
using Results;

public interface IQueryHandler<in TQuery, T>
    : IRequestHandler<TQuery, QueryResult<T>>
    where TQuery : IQuery<T>
{
}