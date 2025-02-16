using Lap2_API.Models;

namespace Lap2_API.Reposartry
{
    public class StudentReposatry : IRepoDeptAndCourse<Student>
    {
        ITIContext db;
        public StudentReposatry(ITIContext db)
        {
            this.db = db;
        }
        public void Add(Student item)
        {
            db.Students.Add(item);
        }

        public void Delete(int id)
        {
            db.Remove(GetById(id));
        }

        public Student GetById(int id)
        {
           return db.Students.Find(id);
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public void Update(Student item)
        {
           db.Students.Update(item);
        }
    }
}
