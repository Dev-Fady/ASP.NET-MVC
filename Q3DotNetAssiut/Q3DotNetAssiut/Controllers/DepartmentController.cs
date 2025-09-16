using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.Models.Repository;

namespace Q3DotNetAssiut.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext context=new ITIContext();

        private readonly IDepartmentRepository _departmentRepo;
        private readonly IEmployeeRepository empRepo;

        public DepartmentController([FromServices]IDepartmentRepository deptRepo,IEmployeeRepository empRepo)
        {
            _departmentRepo = deptRepo; // new DepartmentRepository();
            this.empRepo = empRepo;
        }
        [Authorize]
        public IActionResult GellAllDepartment()
        {
            List<Department> departmantList =
               _departmentRepo.GetAll();
            return View("GellAllDepartment", departmantList);
        }

        // /Department/Add
        public IActionResult Add()
        {
            return View("Add");
        }

        // /Department/SaveAdd ? name="popop" $MangerName="FADDDDy"
        [HttpPost]
        public IActionResult SaveAdd(Department department)
        {
            if(department.Name !=null && department.MangerName != null)
            {
                //context.Departments.Add(department);
                _departmentRepo.Add(department);
                //context.SaveChanges();
                _departmentRepo.Save();
                //return View("GellAllDepartment",context.Departments.ToList());
                // Call Action From Another Action
                return RedirectToAction("GellAllDepartment");
            }
            return View("Add");
        }

        public IActionResult EmpDept()
        {
            return View("EmpDept", _departmentRepo.GetAll());
        }
        public IActionResult GetEmpsByDeptID(int deptID)
        {
            List<Employee> EmpList=empRepo.GetByDeptId(deptID);
            return Json(EmpList);
        }
    }
}
