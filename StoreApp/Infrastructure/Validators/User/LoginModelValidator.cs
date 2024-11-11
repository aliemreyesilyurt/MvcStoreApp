using FluentValidation;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Validators.User;
public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("UserName is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required!");
    }
}
