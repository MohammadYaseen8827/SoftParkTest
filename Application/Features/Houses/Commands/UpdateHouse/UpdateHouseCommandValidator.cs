using FluentValidation;

namespace Platform.Application.Features.Houses.Commands.UpdateHouse;

public class UpdateHouseCommandValidator : AbstractValidator<UpdateHouseCommand>
{
    public UpdateHouseCommandValidator()
    {
        RuleFor(v => v.ImageUrl)
           .NotNull();
        RuleFor(v => v.OfferType).NotNull();
        RuleFor(v => v.Address).NotNull();
    }
}
