using Microsoft.AspNetCore.Identity;

namespace Q3DotNetAssiut.Models
{
    public class ApplicationUser:IdentityUser
    {
        public String? Address { get; set; }
    }
}
