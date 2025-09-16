using Microsoft.EntityFrameworkCore;

namespace Q3DotNetAssiut.Models.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department department);
        public void Update(Department department);
        public void Delete(int id);
        public List<Department> GetAll();
        public Department GetByID(int Id);
        public void Save();
    }
}
