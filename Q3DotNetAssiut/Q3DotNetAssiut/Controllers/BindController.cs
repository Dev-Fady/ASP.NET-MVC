using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Models;
using System.Diagnostics.Metrics;

namespace Q3DotNetAssiut.Controllers
{
    public class BindController : Controller
    {
        public IActionResult TestPrmitive(string name , int age, string[] color)
        {
            return Content($"{name} \t {age} \t {color.Length}");
        }

        //Bind Collection
        //Bind/TestDic?name=alaa&Phones[Ahmed]=123&phones[chris]=456
        public IActionResult TestDic(Dictionary<string,string> Phones,string name)
        {
            string p="";
            foreach (var item in Phones)
            {
                p += item.Value;
            }
            return Content($"{p}\t {name}");
        }

        //  /Bind/testObj? id = 5 & name = roro & name = Fady & mangerName = tom
        public IActionResult TestObj(Department dep,string name)
        {
            return Content($"{dep.Name}\t{dep.Id}\t{name}");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
