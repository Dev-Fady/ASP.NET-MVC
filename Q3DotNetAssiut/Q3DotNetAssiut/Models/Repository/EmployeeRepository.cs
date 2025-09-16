using Microsoft.EntityFrameworkCore;

namespace Q3DotNetAssiut.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ITIContext _context;
        public EmployeeRepository(ITIContext _context)
        {
            this._context = _context; //new ITIContext();
        }
        //CRUD

        public void Add(Employee employee)
        {
            _context.Add(employee);
        }
        public void Update(Employee employee)
        {
            _context.Update(employee);
        }
        public void Delete(int id)
        {
            Employee employee = GetByID(id);
            if (employee != null)
            {
                _context.Remove(employee);
            }
        }
        public List<Employee> GetAll()
        {
            return _context.Employees.AsNoTracking().ToList();
        }
        public Employee GetByID(int Id)
        {

            return _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Employee> GetByDeptId(int DeptId)
        {
            return _context.Employees.Where(e=>e.DepartmentId == DeptId).ToList();
        }
    }
}
