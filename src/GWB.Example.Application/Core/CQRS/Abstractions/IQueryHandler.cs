namespace GWB.Example.Application.Core.Abstractions;

using GWB.Example.Application.Core.Results;
using MediatR;

public interface IQueryHandler<in TQuery, T> 
    : IRequestHandler<TQuery, QueryResult<T>>
        where TQuery : IQuery<T>
{ }