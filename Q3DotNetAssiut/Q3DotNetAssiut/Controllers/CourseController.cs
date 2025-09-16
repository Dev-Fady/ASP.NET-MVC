using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult CheckName(string Name,string hours)
        {
            if (Name.Contains("ITI"))
            {
                return Json(true);
            }
            return Json(false);
        }
      ITIContext context = new ITIContext(); 
        public IActionResult CheckUniqueName(string name)
        {
            bool exists = context.Courses.Any(c => c.Name == name);

            if (exists)
            {
                return Json(false); // not valid
            }

            return Json(true); // valid
        }

       
        public IActionResult Index()
        {
            List<Course> Courses = context.Courses
                  .Include(x => x.Department)
                  .Include(x => x.Instructors)
                  .Include(X => X.CrsResults)
                  .ToList();
            return View("Index",Courses);
        }

        public IActionResult AddCourse()
        {
            ViewData["DeptList"] = context.Departments.ToList();
            return View("AddCourse");
        }
        [HttpPost]
        public IActionResult SaveCourse(Course CourseFromRequest)
        {
                if (ModelState.IsValid)
                {
                    if (CourseFromRequest.dept_id!=0)
                    {
                        try
                        {
                            context.Courses.Add(CourseFromRequest);
                            context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        catch(Exception ex)
                        {
                            ModelState.AddModelError("", ex.Message);
                        }
                    }
                    else
                    {
                       ModelState.AddModelError("dept_id", "Select any Department ");
                    }
                }
            ViewData["DeptList"] = context.Departments.ToList();
            return View("AddCourse", CourseFromRequest);
        }
    }
}
