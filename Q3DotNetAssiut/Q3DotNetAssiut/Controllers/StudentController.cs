using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.Controllers
{
    public class StudentController : Controller
    {
        // /Student/ShowAll
        public IActionResult ShowAll()
        {
            StudentBL studentBL = new StudentBL();
            List<Student> studentListModel = studentBL.GetAll();
            return View("ShowAll",studentListModel);
        }
        public IActionResult ShowDetails(int Id)
        {
            StudentBL studentBL = new StudentBL();
            Student studentModel = studentBL.GetById(Id);
            return View("ShowDetails", studentModel);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
