using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Q3DotNetAssiut.ViewModel;
using System.Threading.Tasks;

namespace Q3DotNetAssiut.Controllers
{
    [Authorize(Roles="admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View("AddRole");
        }

        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleNme;

                IdentityResult res = await roleManager.CreateAsync(role);

                if (res.Succeeded) {
                    ViewBag.sucess = true;
                    return View("AddRole");
                }
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View("AddRole",roleViewModel);
        }
    }
}
