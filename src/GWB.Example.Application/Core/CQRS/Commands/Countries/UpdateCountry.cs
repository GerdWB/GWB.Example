namespace GWB.Example.Application.Core.Commands;

using Domain;
using GWB.Example.Application.Core.Abstractions;
using Results;
using Services;

public static partial class Countries
{
    public static class Update
    {
        public sealed record Command(Country Country) : ICommand;

        public class Handler : ICommandHandler<Command>
        {
            private readonly ICountryCommandService _templateTreeCommandService;

            public Handler(ICountryCommandService templateTreeCommandService) =>
                _templateTreeCommandService = templateTreeCommandService;

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken) =>
                // Validation here or within the command chain
                await _templateTreeCommandService.UpdateAsync(request.Country);
        }
    }
}