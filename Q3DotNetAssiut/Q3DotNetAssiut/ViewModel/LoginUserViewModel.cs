using System.ComponentModel.DataAnnotations;

namespace Q3DotNetAssiut.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="*")]
        public String Name { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name="Remember Me!")]
        public bool RememberMe { get; set; } 
    }
}
