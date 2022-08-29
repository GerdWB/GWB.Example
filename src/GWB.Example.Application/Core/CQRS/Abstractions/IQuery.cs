namespace GWB.Example.Application.Core.Abstractions;

using GWB.Example.Application.Core.Results;
using MediatR;

public interface IQuery<T> : IRequest<QueryResult<T>>
{ }
