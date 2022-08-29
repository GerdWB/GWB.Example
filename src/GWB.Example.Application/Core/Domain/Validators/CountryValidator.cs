namespace GWB.Example.Application.Core.Domain.Validators;

using Entities;
using FluentValidation;

public sealed class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(80).MinimumLength(2);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300).MinimumLength(32);
    }
}