using FluentValidation;

namespace Platform.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.LastName)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.PhoneNumbers)
            .NotEmpty();
        RuleFor(v => v.Addresses)
            .NotEmpty();
    }
}
