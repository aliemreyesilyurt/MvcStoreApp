using Entities.Dtos.User;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.User;
public class ResetPassDtoValidator : AbstractValidator<ResetPasswordDto>
{
    public ResetPassDtoValidator()
    {
        RuleFor(r => r.UserName)
            .NotEmpty().WithMessage("UserName is required!");

        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Password is required!")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

        RuleFor(r => r.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password is required!")
            .Equal(r => r.Password).WithMessage("The password and confirmation password do not match.");
    }
}

