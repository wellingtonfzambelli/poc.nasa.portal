using FluentValidation;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;

public sealed class GetPictureOfTheDayValidator : AbstractValidator<GetPictureOfTheDayRequestDto>
{
    public GetPictureOfTheDayValidator() =>
        RuleFor(s => s.Date)
            .Must(ValidateDateGreaterThan).WithErrorCode(MessageValidation.DateLessThan.code)
                                          .WithMessage(MessageValidation.DateLessThan.description);

    private bool ValidateDateGreaterThan(DateTime date) =>
        date > DateTime.Parse("2020-01-01");
}