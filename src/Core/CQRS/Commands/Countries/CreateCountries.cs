// ReSharper disable UnusedMember.Global

namespace GWB.Example.Application.Core.Commands;

public static partial class Countries
{
    public static class Create
    {
        public sealed record Command(IEnumerable<Country> Countries) : ICommand;

        public class Handler : ICommandHandler<Command>
        {
            private readonly ICountryCommandService _templateTreeCommandService;

            public Handler(ICountryCommandService templateTreeCommandService) =>
                _templateTreeCommandService = templateTreeCommandService;

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken) =>
                // Validation here or within the command chain
                await _templateTreeCommandService.CreateAsync(request.Countries);
        }
    }
}