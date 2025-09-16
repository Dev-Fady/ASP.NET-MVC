using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.ViewModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Q3DotNetAssiut.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

      

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
              ////UserManager<ApplicationUser> manager=new UserManager<ApplicationUser>()

                // 1- Mapping
                ApplicationUser appUser = new ApplicationUser();
                appUser.Address = registerUser.Address;
                appUser.UserName = registerUser.UserName;
                appUser.PasswordHash = registerUser.Password;

                // 2-save database
                IdentityResult res = 
                    await userManager.CreateAsync(appUser,registerUser.Password);

                // 3- cookie
                if (res.Succeeded)
                {
                    // assign ro Role
                    await userManager.AddToRoleAsync(appUser, "Admin");

                    // 3- cookie
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("GellAllDepartment", "Department");

                }
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("Register", registerUser);
        }
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid) {
                // 1-check found
                ApplicationUser appUser = await userManager.FindByNameAsync(userViewModel.Name);
                if (appUser != null) {
                    bool found = await userManager.CheckPasswordAsync(appUser,userViewModel.Password);
                    if (found)
                    {
                        // 2-create cookie

                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", appUser.Address));

                        await signInManager.SignInWithClaimsAsync(appUser, userViewModel.RememberMe, claims);
                        //await signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("GellAllDepartment", "Department");
                    }

                }
                ModelState.AddModelError("", "UserName or Password Wrong");
            }
            return View("Login",userViewModel);
        }
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Register");
        }
    }
}
