﻿using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();
        Task<UserDtoForUpdate> GetOneUserForUpdate(string id);
        Task<IdentityUser> GetOneUser(string userName);
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task UpdateOneUser(string id, UserDtoForUpdate userDto);
    }
}
