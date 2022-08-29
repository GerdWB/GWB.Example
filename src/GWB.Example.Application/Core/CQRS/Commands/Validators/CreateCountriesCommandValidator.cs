namespace GWB.Example.Application.Core.Commands.Validators;

using Countries;
using Domain.Validators;
using FluentValidation;

public sealed class CreateCountriesCommandValidator : AbstractValidator<Countries.Create.Command>
{
    public CreateCountriesCommandValidator()
    {
        RuleFor(x => x.Countries).NotNull();
        RuleForEach(x => x.Countries).SetValidator(new CountryValidator());
    }
}