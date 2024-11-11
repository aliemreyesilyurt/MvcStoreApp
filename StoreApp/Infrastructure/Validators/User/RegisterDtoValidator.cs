using Entities.Dtos.User;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.User;
public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage("UserName is required.")
            .MinimumLength(5).WithMessage("UserName must be at least 5 characters.")
            .MaximumLength(50).WithMessage("UserName must be less than 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required!")
            .EmailAddress().WithMessage("Please enter a valid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required!")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.PhoneNumber)
                .Matches(@"^05\d{9}$")
                .WithMessage("Please enter a valid phone number.");

    }
}

