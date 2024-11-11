using Entities.Dtos.User;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.User;
public class UserDtoCreationValidator : AbstractValidator<UserDtoForCreation>
{
    public UserDtoCreationValidator()
    {
        Include(new UserDtoValidator());

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required!")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

    }
}

