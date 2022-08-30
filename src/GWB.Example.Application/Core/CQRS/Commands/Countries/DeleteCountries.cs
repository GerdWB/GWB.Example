// ReSharper disable UnusedMember.Global

namespace GWB.Example.Application.Core.Commands;

using Abstractions;
using Domain.Entities;
using Results;
using Services;

public static partial class Countries
{
    public static class Delete
    {
        public sealed record Command(IEnumerable<Country> Countries) : ICommand;

        public class Handler : ICommandHandler<Command>
        {
            private readonly ICountryCommandService _templateTreeCommandService;

            public Handler(ICountryCommandService templateTreeCommandService) =>
                _templateTreeCommandService = templateTreeCommandService;

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken) =>
                // Validation here or within the command chain
                await _templateTreeCommandService.DeleteAsync(request.Countries);
        }
    }
}