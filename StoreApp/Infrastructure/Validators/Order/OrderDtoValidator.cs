using Entities.Dtos.Order;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.Order
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(o => o.Fullname)
                .NotEmpty().WithMessage("Fullname is required.")
                .MinimumLength(5).WithMessage("Fullname must be at least 5 characters.")
                .MaximumLength(30).WithMessage("Fullname must be less than 30 characters.");

            RuleFor(o => o.Line1)
                .NotEmpty().WithMessage("Line1 adress is required.")
                .MinimumLength(10).WithMessage("Line1 address must be at least 10 characters.")
                .MaximumLength(100).WithMessage("Line1 address must be less than 100 characters.");

            RuleFor(o => o.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City must be less than 100 characters.");
        }
    }
}
