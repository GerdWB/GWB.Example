using GWB.Example.Application.Core.Commands;

namespace GWB.Example.Application.Core.CQRS.Commands.Validators;

using FluentValidation;
using GWB.Example.Application.Core.Domain.Validators;

public sealed class CreateCountriesCommandValidator : AbstractValidator<Countries.Create.Command>
{
    public CreateCountriesCommandValidator()
    {
        RuleFor(x => x.Countries).NotNull();
        RuleForEach(x => x.Countries).SetValidator(new CountryValidator());
    }
}