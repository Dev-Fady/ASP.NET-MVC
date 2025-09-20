using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAPICor.net.DTO;
using WepAPICor.net.Models;

namespace WepAPICor.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Assiut_DotNet_Q3Context context;

        public EmployeeController(Assiut_DotNet_Q3Context _context)
        {
            context = _context;
        }
        private GeneralResponse GetModelErrors()
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return new GeneralResponse
            {
                IsSuccess = false,
                Data = errors
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> Get(int id) {
            var res = context.Employees
                .Where(x => x.Id == id)
                .Include(x => x.Department)
                .Select(
                x => new
                {
                    x.Id,
                    x.Name,
                    x.Salary,
                    x.ImageUrl,
                    saray = x.Salary,
                    x.JopTitle,
                    DepartmentName = x.Department.Name,
                    DepartmentId = x.Department.Id
                }).FirstOrDefault();
            if (res == null)
            {
                return NotFound(new GeneralResponse
                {
                    IsSuccess = false,
                    Data = "ID not valid"
                });
            }
            return Ok(new GeneralResponse
            {
                IsSuccess = true,
                Data = res
            });
        }
        [HttpGet("{name:alpha}")]
        public ActionResult<GeneralResponse> Get(String name)
        {
            var res = context.Employees
                .Where(x => x.Name == name)
                .Include(x => x.Department)
                .Select(
                x => new
                {
                    x.Id,
                    x.Name,
                    x.Salary,
                    x.ImageUrl,
                    saray = x.Salary,
                    x.JopTitle,
                    DepartmentName = x.Department.Name,
                    DepartmentId = x.Department.Id
                }).FirstOrDefault();
            if (res == null)
            {
                return NotFound(new GeneralResponse
                {
                    IsSuccess = false,
                    Data = "ID not valid"
                });
            }
            return Ok(new GeneralResponse
            {
                IsSuccess = true,
                Data = res
            });
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetModelErrors());

            var employee = new Employee
            {
                Name = dto.Name,
                Salary = dto.Salary,
                JopTitle = dto.JopTitle,
                ImageUrl = dto.ImageUrl,
                DepartmentId = dto.DepartmentId
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            return Ok(new GeneralResponse
            {
                IsSuccess = true,
                Data = "Employee created successfully"
            });
        }

        //public IActionResult Get(int id)
        //{
        //    var res = context.Employees
        //        .Where(x => x.Id == id)
        //        .Include(x => x.Department)
        //        .Select(
        //        x => new
        //        {
        //            x.Id,
        //            x.Name,
        //            x.Salary,
        //            x.ImageUrl,
        //            saray = x.Salary,
        //            x.JopTitle,
        //            DepartmentName = x.Department.Name,
        //            DepartmentId = x.Department.Id
        //        });
        //    GeneralResponse generalResponse = new GeneralResponse();
        //    if (res != null)
        //    {
        //        generalResponse.IsSuccess = true;
        //        generalResponse.Data = res;
        //    }
        //    else
        //    {
        //        generalResponse.IsSuccess = false;
        //        generalResponse.Data = "ID in Valid";
        //    }
        //    return Ok(generalResponse);
        //}
    }
}
