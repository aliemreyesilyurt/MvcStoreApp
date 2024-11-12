using Entities.Dtos.User;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.User;
public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
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

        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage("Firstname is required.")
            .MinimumLength(2).WithMessage("Firstname must be at least 5 characters.")
            .MaximumLength(50).WithMessage("Firstname must be less than 50 characters.");

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("Lastname is required.")
            .MinimumLength(2).WithMessage("Lastname must be at least 5 characters.")
            .MaximumLength(50).WithMessage("Lastname must be less than 50 characters.");

        RuleFor(u => u.Age)
            .NotEmpty().WithMessage("Age is required.")
            .GreaterThan(18).WithMessage("Your age must be at least 18.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required!")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

    }
}

