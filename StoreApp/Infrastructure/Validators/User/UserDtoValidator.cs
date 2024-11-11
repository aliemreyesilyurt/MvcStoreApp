using Entities.Dtos.User;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("Username must be at least 5 characters.")
                .MaximumLength(50).WithMessage("Username must be less than 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^05\d{9}$")
                .WithMessage("Please enter a valid phone number.");

            RuleFor(x => x.Roles)
                .NotEmpty().WithMessage("Roles collection must contain at least one item.")
                .Must(roles => roles?.Count > 0).WithMessage("Roles collection must contain at least one item.");
        }
    }
}
