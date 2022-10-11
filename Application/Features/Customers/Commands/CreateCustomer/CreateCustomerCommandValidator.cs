using FluentValidation;

namespace Platform.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
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
