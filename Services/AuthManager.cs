using AutoMapper;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles =>
            _roleManager.Roles;

        // Create
        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
                throw new Exception("User could not be created!");

            if (userDto.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                    throw new Exception("System has problems with roles!");
            }
            else if (userDto.Roles.Count == 0)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (!roleResult.Succeeded)
                    throw new Exception("System has problems with roles!");
            }

            return result;
        }

        // Get All
        public IEnumerable<IdentityUser> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return users;
        }

        // Get One By UserName
        public async Task<IdentityUser> GetOneUserByUsername(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is not null)
                return user;

            throw new Exception("User could not be found!");
        }

        // Get One By Id
        public async Task<IdentityUser> GetOneUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is not null)
                return user;

            throw new Exception("User could not be found!");

        }

        // Get One For Update
        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string id)
        {
            var user = await GetOneUserById(id);

            var userDto = _mapper.Map<UserDtoForUpdate>(user);
            userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));

            return userDto;

        }

        // Update
        public async Task UpdateOneUser(string id, UserDtoForUpdate userDto)
        {
            var user = await GetOneUserById(id);
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
                throw new Exception("User could not be updated!");

            if (userDto.Roles.Count > 0)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                    throw new Exception("System has problems with roles!");
            }
        }

        // Delete
        public async Task<IdentityResult> DeleteOneUser(string userName)
        {
            var user = await GetOneUserByUsername(userName);
            var deleteResult = await _userManager.DeleteAsync(user);

            if (!deleteResult.Succeeded)
                throw new Exception("User could not be deleted!");

            return deleteResult;
        }

        // Reset Password
        public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await GetOneUserByUsername(model.UserName);

            var removePassResult = await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, model.Password);

            return result;

        }
    }
}
