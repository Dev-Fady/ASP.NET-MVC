namespace Q3DotNetAssiut.Models.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee employee);


        public void Update(Employee employee);


        public void Delete(int id);


        public List<Employee> GetAll();


        public Employee GetByID(int Id);


        public void Save();
     
        public List<Employee> GetByDeptId(int DeptId);
    }
}
