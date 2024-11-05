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

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return users;
        }

        public async Task<IdentityUser> GetOneUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string id)
        {
            var user = await GetOneUserById(id);

            if (user is not null)
            {
                var userDto = _mapper.Map<UserDtoForUpdate>(user);
                //userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
                userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));

                return userDto;
            }
            throw new Exception("An error occured!");
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is not null)
            {
                var removePassResult = await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, model.Password);

                return result;
            }
            throw new Exception("User coudl not be found!");
        }

        public async Task UpdateOneUser(string id, UserDtoForUpdate userDto)
        {
            var user = await GetOneUserById(id);
            user.UserName = userDto.Username;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;

            if (user is not null)
            {
                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                    throw new Exception("User could not be updated!");

                if (userDto.Roles.Count > 0)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, userRoles);

                    var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                    if (!roleResult.Succeeded)
                        throw new Exception("System has problems with roles!");
                }
                return;
            }
            throw new Exception("System has problem with user update!");

        }
    }
}
