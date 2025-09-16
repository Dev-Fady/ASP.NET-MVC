using Microsoft.AspNetCore.Mvc;

namespace Q3DotNetAssiut.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", 21);
            return Content("Data Session Save Success");
        }
        public IActionResult GetSession()
        {
            string? name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Data Name={name}, age={age}");
        }
        public IActionResult SetCookie(String name,int age)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Name", name);
            HttpContext.Response.Cookies.Append("age", age.ToString(),options);
            return Content("Cookiw Save");
        }
        public IActionResult GetCookie()
        {
            string name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["age"];
            return Content($"Date Name={name} age={age}");
        }
    }
}
