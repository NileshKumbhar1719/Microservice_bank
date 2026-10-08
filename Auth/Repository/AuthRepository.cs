using Auth.Model;
using Microsoft.AspNetCore.Identity;

namespace Auth.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<UserRegister> _managerUser;
        private SignInManager<UserRegister> _signinmanger;
        private readonly RoleManager<IdentityRole> RoleUser;

        public AuthRepository( 
            UserManager<UserRegister> userManager,
            SignInManager<UserRegister> signInManager,
            RoleManager<IdentityRole> roleManager) 
        {
         this._managerUser = userManager;
         this._signinmanger = signInManager;
         this.RoleUser = roleManager;
        
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegister user, string password)
        {
            var create = await _managerUser.CreateAsync(user, password);
            return create;
        }

        public async Task<UserRegister> FindByUsernameAsync(string username)
        {
            return await _managerUser.FindByNameAsync(username);
        }

        public async Task<UserRegister> FindByEmailAsync(string email)
        {
            return await _managerUser.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(UserRegister user, string password)
        {
           return await _managerUser.CheckPasswordAsync(user, password);
        }

        public async Task<bool> RoleExistsAsync(string role)
        {
            return await RoleUser.RoleExistsAsync(role);
        }

        public async Task<IdentityResult> CreateRoleAsync(string role)
        {
             return await RoleUser.CreateAsync(new IdentityRole(role));
        }

        public async Task<IdentityResult> AddToRoleAsync(UserRegister user, string role)
        {
            return await _managerUser.AddToRoleAsync(user, role);
        }

        public async Task SignOutAsync()
        {
             await _signinmanger.SignOutAsync();
        }

        public async Task<IList<string>> GetRolesAsync(UserRegister user)
        {
           return await  _managerUser.GetRolesAsync(user);
        }
    }
}
