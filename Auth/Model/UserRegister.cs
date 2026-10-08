using Microsoft.AspNetCore.Identity;

namespace Auth.Model
{
    public class UserRegister : IdentityUser
    {

       public  string FullName {  get; set; }= string.Empty;

        public string Address { get; set; } = string.Empty;

    }
}
