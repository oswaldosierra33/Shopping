using Microsoft.AspNetCore.Identity;
using Shooping.Data.Entities;
using Shooping.Models;

namespace Shooping.Data.Helpers
{
    public interface IUserHelper
    {
        // metodo para obtener un usuario por su correo electronico
        Task<User> GetUserAsync(string email);
        // metodo para obtener un usuario por su id
        Task<IdentityResult> AddUserAsync(User user, string password);
        // metodo para verificar y crear un rol si no existe
        Task CheckRoleAsync(string roleName);
        
        Task AddUserToRoleAsync(User user, string roleName);
        // metodo para verificar si un usuario pertenece a un rol
        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


    }
}
