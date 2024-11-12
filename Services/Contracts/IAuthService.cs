using Entities.Dtos.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<User> GetAllUsers();
        Task<UserDtoForUpdate> GetOneUserForUpdate(string id);
        Task<User> GetOneUserById(string id);
        Task<User> GetOneUserByUsername(string userName);
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task UpdateOneUser(string id, UserDtoForUpdate userDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto model);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}
