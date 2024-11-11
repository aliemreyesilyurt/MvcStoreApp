using FluentValidation;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Validators.User;
public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(5).WithMessage("UserName must be at least 5 characters.")
                .MaximumLength(50).WithMessage("UserName must be less than 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required!")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
    }
}
