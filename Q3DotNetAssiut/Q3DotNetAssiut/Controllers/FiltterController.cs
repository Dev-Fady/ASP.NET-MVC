using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Filters;

namespace Q3DotNetAssiut.Controllers
{
    //[HandelErrorAttribute]
    //[Authorize]
    public class FiltterController : Controller
    {
        [HandelErrorAttribute]
        public IActionResult Index()
        {
            throw new Exception("EXCPTION fr index");
        }
        [Authorize]
        public IActionResult Index2()
        {
            throw new Exception("EXCPTION fr index2222222");
        }
    }
}
