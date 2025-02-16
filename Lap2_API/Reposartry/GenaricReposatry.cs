
using Lap2_API.Models;

namespace Lap2_API.Reposartry
{
    public class GenaricReposatry<T> : IRepoDeptAndCourse<T> where T : class
    {
        private readonly ITIContext db;

        public GenaricReposatry(ITIContext db)
        {
            this.db = db;
        }
        public void Add(T item)
        {
            db.Add(item);
        }

        public void Delete(int id)
        {
            db.Remove(GetById(id));
        }

        public List<T> GetAll()
        {
           return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
