using Lap2_API.Models;

namespace Lap2_API.Reposartry
{
    public class DepartmentReposatry : IRepoDeptAndCourse<Department>
    {
        private readonly ITIContext db;

        public DepartmentReposatry(ITIContext db)
        {
            this.db = db;
        }
        public void Add(Department item)
        {
            db.Departments.Add(item);
        }

        public void Delete(int id)
        {
            db.Departments.Remove(GetById(id)); 
        }

        public List<Department> GetAll()
        {
           return db.Departments.ToList();
        }

        public Department GetById(int id)
        {
           return db.Departments.Find(id);
        }

        public void Update(Department item)
        {
            db.Departments.Update(item);
        }
    }
}
