using Q3DotNetAssiut.Models;
using System.ComponentModel.DataAnnotations;

namespace Q3DotNetAssiut.ViewModel
{
    public class RegisterUserViewModel
    {
        //[UniqueNameAttribute<RegisterUserViewModel>("UserName")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public String Address { get; set; }

    }
}
