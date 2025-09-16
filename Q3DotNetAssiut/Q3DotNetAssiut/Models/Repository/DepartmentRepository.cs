using Microsoft.EntityFrameworkCore;

namespace Q3DotNetAssiut.Models.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ITIContext _context;
        public DepartmentRepository(ITIContext _context)
        {
            this._context = _context; //new ITIContext();
        }  
        //CRUD

        public void Add(Department department)
        {
            _context.Add(department);
        }
        public void Update(Department department)
        {
            _context.Update(department);
        }
        public void Delete(int id)
        {
            Department department = GetByID(id);
            if (department != null) { 
                _context.Remove(department);
            }
        }
        public List<Department> GetAll()
        {
            return _context.Departments.AsNoTracking().ToList();
        }
        public Department GetByID(int Id) {

            return _context.Departments.AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
