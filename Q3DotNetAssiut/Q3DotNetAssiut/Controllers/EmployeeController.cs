using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.Models.Repository;
using Q3DotNetAssiut.ViewModel;

namespace Q3DotNetAssiut.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext context=new ITIContext();
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController([FromServices]IDepartmentRepository depatRepo, [FromServices]IEmployeeRepository employeeRepo)
        {
            _departmentRepo = depatRepo;//new DepartmentRepository();
            _employeeRepository = employeeRepo;//new EmployeeRepository();
        }

        public IActionResult Details(int Id)
        {
            string msg = "Hello From Action";
            int temp = 50;
            List<String> bracnches = new List<String>();
            bracnches.Add(msg);
            bracnches.Add("Fady");
            bracnches.Add("Fady2");
            bracnches.Add("Fady30");
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["bra"] = bracnches;

            ViewBag.Color = "Red";

            var Employee = _employeeRepository.GetByID(Id);
            return View("SomeDetails", Employee);
        }

        public ActionResult DetailsVM(int Id)
        {
            var Employee = _employeeRepository.GetByID(Id);

            List<String> bracnches = new List<String>();
            //bracnches.Add(msg);
            bracnches.Add("Fady");
            bracnches.Add("Fady2");
            bracnches.Add("Fady30");

            EmpDeptColorTempMsgBrchViewModel EmpVM = new EmpDeptColorTempMsgBrchViewModel();
            // Mapping
            EmpVM.DeptName = Employee.Department.Name;
            EmpVM.EmpName = Employee.Name;
            EmpVM.employee = Employee;
            EmpVM.Msg = "HElllllo";
            EmpVM.Temp = 12;
            EmpVM.Color = "red";
            EmpVM.Branches = bracnches;
            return View("DetailsVM",EmpVM);
        }

        public IActionResult Index()
        {
            return View("Index", _employeeRepository.GetAll());
        }

        public IActionResult Edit(int Id)
        {
            /*  Employee Emp=context.Employees.FirstOrDefault(x=>x.Id == Id);
              List<Department> Depts = context.Departments.ToList();
              EmpWithDeptListViewModel empWithDept=new EmpWithDeptListViewModel();

              empWithDept.DepartmentList = Depts;
              empWithDept.MyEmployee = Emp;

              return View("Edit", empWithDept);*/
            Employee Emp = _employeeRepository.GetByID(Id);
            List<Department> DepartmentList = _departmentRepo.GetAll();
            EmpWithDeptListViewModel empWithDept = new EmpWithDeptListViewModel();

            empWithDept.DepartmentList = DepartmentList;
            empWithDept.MyEmployee = Emp;

            return View("Edit", empWithDept);
        }
        [HttpPost]
        public IActionResult SaveEdit(Employee EmpFromRequest,int id) {
            /*  if (EmpFromRequest.Name!=null)
              {
                  Employee EmpFromDB = context.Employees.FirstOrDefault(x => x.Id == id);
                  if (EmpFromDB != null)
                  {
                      EmpFromDB.Name = EmpFromRequest.Name;
                      EmpFromDB.Address = EmpFromRequest.Address;
                      EmpFromDB.Salary = EmpFromRequest.Salary;
                      EmpFromDB.JopTitle = EmpFromRequest.JopTitle;
                      EmpFromDB.DepartmentId = EmpFromRequest.DepartmentId;
                      EmpFromDB.ImageUrl = EmpFromRequest.ImageUrl;
                      context.SaveChanges();
                      return RedirectToAction("Index");
                  }
              }
              return View("Edit", EmpFromRequest);*/

            if (EmpFromRequest.Name != null)
            {
                Employee EmpFromDB = _employeeRepository.GetByID(id);
                if (EmpFromDB != null)
                {
                    EmpFromDB.Name = EmpFromRequest.Name;
                    EmpFromDB.Address = EmpFromRequest.Address;
                    EmpFromDB.Salary = EmpFromRequest.Salary;
                    EmpFromDB.JopTitle = EmpFromRequest.JopTitle;
                    EmpFromDB.DepartmentId = EmpFromRequest.DepartmentId;
                    EmpFromDB.ImageUrl = EmpFromRequest.ImageUrl;
                    _employeeRepository.Update(EmpFromDB);
                    _employeeRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            return View("Edit", EmpFromRequest);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["DeptList"] = _departmentRepo.GetAll();
            return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Employee EmpFromRequest)
        {
            if (EmpFromRequest.Name !=null && EmpFromRequest.Salary>=6000)
            {
                //context.Employees.Add(EmpFromRequest);
                //context.SaveChanges();
                _employeeRepository.Add(EmpFromRequest);
                _employeeRepository.Save();

                return RedirectToAction("Index", _employeeRepository.GetAll());
            }
            ViewData["DeptList"] = _departmentRepo.GetAll();
            return View("New", EmpFromRequest);
        }
    }
}
