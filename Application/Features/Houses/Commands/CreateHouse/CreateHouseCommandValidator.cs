using FluentValidation;

namespace Platform.Application.Features.Houses.Commands.CreateHouse;

public class CreateHouseCommandValidator : AbstractValidator<CreateHouseCommand>
{
    public CreateHouseCommandValidator()
    {
        RuleFor(v => v.ImageUrl).NotNull();
        RuleFor(v => v.OfferType).NotNull();
        RuleFor(v => v.Address).NotNull();
    }
}
