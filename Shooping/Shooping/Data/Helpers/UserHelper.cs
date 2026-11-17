using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shooping.Data;
using Shooping.Data.Entities;
using Shooping.Models;

namespace Shooping.Data.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(DataContext contex, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User>
            signInManager)
        {
            _context = contex;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        // metodo para obtener un usuario por su id
        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }
        // metodo para verificar y crear un rol si no existe
        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }

        }
        // metodo para obtener un usuario por su correo electronico incluyendo la ciudad
        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
            .Include(u => u.City)
            .FirstOrDefaultAsync(u => u.Email == email);

        }
        // metodo para verificar si un usuario pertenece a un rol
        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
