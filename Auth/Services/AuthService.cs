using Auth.Model;
using Auth.Repository;
using System.Threading.Tasks.Dataflow;

namespace Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly IJwtService _jwt;

        public AuthService( IAuthRepository authRepository, IJwtService jwtService)
        {
           this._repo = authRepository; 
           this._jwt = jwtService;
        }

        public async Task<AuthResponse> LoginAsync(Login login)
        {
            var user = await _repo.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return new AuthResponse { IsSuccess = false , Message =" User Not Found"};
            }

            
            if(!await _repo.CheckPasswordAsync(user, login.Password))
            {
                return new AuthResponse { IsSuccess = false, Message = " User Not Found" };
            }

            var roles = await _repo.GetRolesAsync(user);

            string role = roles.FirstOrDefault() ?? "user";

            var token = _jwt.GenerateToken(user.UserName, role);



            return new AuthResponse { IsSuccess = true, Message = "Login Successful", Token=token,  Role = role };
        }

        

        public async Task<AuthResponse> RegisterAsync(Register register)
        {
            var userexititng = await _repo.FindByEmailAsync( register.Email);
            if(userexititng != null)
            {
                return new AuthResponse { IsSuccess = false, Message = "user alredy exiting " };
            }

            var user = new UserRegister
            {


                FullName = register.FullName,
                Email = register.Email,
                UserName = register.UserName,
                Address = register.Address,




            };

            var result = await _repo.CreateUserAsync(user, register.Password);
            if (!result.Succeeded)
                return new AuthResponse { IsSuccess = false, Message = string.Join(", ", result.Errors.Select(e => e.Description)) };

            string role = string.IsNullOrWhiteSpace(register.Role) ? "User" : register.Role.Trim();

            if (!await _repo.RoleExistsAsync(role))
                await _repo.CreateRoleAsync(role);

            await _repo.AddToRoleAsync(user, role);

            var token = _jwt.GenerateToken(user.UserName, role);

            return new AuthResponse { IsSuccess = true, Message = "User Registered Successfully", Token = token, Role = role };

        }

        public async Task LogoutAsync()
        {
            await _repo.SignOutAsync();


        }
    }
}
