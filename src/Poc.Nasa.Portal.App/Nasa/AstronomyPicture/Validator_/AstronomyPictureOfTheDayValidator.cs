using FluentValidation;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

public sealed class AstronomyPictureOfTheDayValidator : AbstractValidator<AstronomyPictureOfTheDayRequestDto>
{
    public AstronomyPictureOfTheDayValidator()
    {
        RuleFor(s => s.Date)
            .Must(ValidateDateGreaterThan).WithErrorCode(MessageValidation.DateLessThan.code).WithMessage(MessageValidation.DateLessThan.description);
    }

    private bool ValidateDateGreaterThan(DateTime date) =>
        date > DateTime.Parse("2020-01-01");
}