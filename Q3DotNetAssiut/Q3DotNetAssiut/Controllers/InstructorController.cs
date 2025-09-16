using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.ViewModel;

namespace Q3DotNetAssiut.Controllers
{
    public class InstructorController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            return View("Index", instructors);
        }

        public IActionResult AllDetails(int id)
        {
            Instructor? instructor = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(x => x.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View("AllDetails", instructor);
        }

        public IActionResult Edit(int id)
        {
            Instructor? instructor = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(x => x.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            List<Department> Depts = context.Departments.ToList();
            List<Course> courses = context.Courses.ToList();
            InstructorWithDeptsAndCourses InstructorDeptsCousrses=new InstructorWithDeptsAndCourses();
            InstructorDeptsCousrses.MyInstructor = instructor;
            InstructorDeptsCousrses.Courses = courses;
            InstructorDeptsCousrses.Depts=Depts;
            
            return View("Edit", InstructorDeptsCousrses);
        }
        [HttpPost]
        public IActionResult SaveEdit(Instructor InstructorFromRequest, int id)
        {
            // نجيب الـ Instructor القديم من الـ DB
            Instructor? oldInstructor = context.Instructors.FirstOrDefault(i => i.Id == id);

            if (ModelState.IsValid)
            {
                // نحدّث القيم
                oldInstructor.Name = InstructorFromRequest.Name;
                oldInstructor.Salary = InstructorFromRequest.Salary;
                oldInstructor.Address = InstructorFromRequest.Address;
                oldInstructor.ImageUrl = InstructorFromRequest.ImageUrl;
                oldInstructor.dept_id = InstructorFromRequest.dept_id;
                oldInstructor.crs_id = InstructorFromRequest.crs_id;

                // نحفظ في الـ DB
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            // لو فيه أخطاء Validation نرجع نفس الـ ViewModel
            var vm = new InstructorWithDeptsAndCourses
            {
                MyInstructor = InstructorFromRequest,
                Depts = context.Departments.ToList(),
                Courses = context.Courses.ToList()
            };

            return View("Edit", vm);
        }

    }
}
