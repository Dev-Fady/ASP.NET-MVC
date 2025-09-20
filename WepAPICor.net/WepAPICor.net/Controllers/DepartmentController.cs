using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAPICor.net.Models;

namespace WepAPICor.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly Assiut_DotNet_Q3Context context;

        public DepartmentController(Assiut_DotNet_Q3Context _Context)
        {
            context = _Context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult DisplayAllDept()
        {
            var deptList = context.Departments1
                    .Include(e => e.Employees)
                    .Select(d => new {
                        d.Id,
                        d.Name,
                        EmployeesCount= d.Employees.Count(),
                        Employees = d.Employees.Select(emp => new {
                            emp.Id,
                            emp.Name,
                            emp.Salary
                        }).ToList()
                    })
                    .ToList();
            return Ok(deptList);
        }
        [HttpGet]
        [Route("{ID:int}")] // api/Department/1
        public IActionResult GetById(int ID)
        {
            var dept = context.Departments1
                .Include(d => d.Employees)
                .Where(d => d.Id == ID)
                .Select(d => new {
                    d.Id,
                    d.Name,
                    EmployeesCount = d.Employees.Count(),
                    Employees = d.Employees.Select(emp => new {
                        emp.Id,
                        emp.Name,
                        emp.Salary
                    }).ToList()
                })
                .FirstOrDefault();

            if (dept == null)
            {
                return NotFound(new { message = $"Department with ID {ID} not found." });
            }

            return Ok(dept);
        }


        [HttpGet("{Name:alpha}")]//api/Department/{Name}
        //[Route("{Name}")]//api/Department/{Name}
        public IActionResult GetByName(String Name)
        {
            Department1 dept = context.Departments1.FirstOrDefault(x => x.Name == Name);
            return Ok(dept);
        }

        [HttpPost]
        public IActionResult AddDept(Department1 dept)
        {
            context.Departments1.Add(dept);
            context.SaveChanges();
            //return Created($"http://localhost:5025/api/Department/{dept.Id}",dept);
            return CreatedAtAction("GetById", new {Id=dept.Id} ,dept);
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateDept(int Id,Department1 deptFromRequest)
        {
            Department1 deptFromDb = context.Departments1.FirstOrDefault(x => x.Id == Id);

            if (deptFromDb!=null)
            {
                deptFromDb.Name = deptFromRequest.Name;
                deptFromDb.MangerName = deptFromRequest.MangerName;
                context.SaveChanges();
                //return Created($"http://localhost:5025/api/Department/{dept.Id}",dept);
                //return CreatedAtAction("GetById", new { Id = Id }, deptFromRequest);
                return NoContent();
            }
            else
            {
                return NotFound("Department Not Found");
            }
        }

    }
}
