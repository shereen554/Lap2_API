namespace Lap2_API.Reposartry
{
    public interface IRepoDeptAndCourse<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Add(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}
