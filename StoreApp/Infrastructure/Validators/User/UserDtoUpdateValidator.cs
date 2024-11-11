using Entities.Dtos.User;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.User;
public class UserDtoUpdateValidator : AbstractValidator<UserDtoForUpdate>
{
    public UserDtoUpdateValidator()
    {
        Include(new UserDtoValidator());
    }
}

