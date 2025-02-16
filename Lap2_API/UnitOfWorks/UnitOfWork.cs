using Lap2_API.Models;
using Lap2_API.Reposartry;

namespace Lap2_API.UnitOfWorks
{
    public class UnitOfWork
    {
        GenaricReposatry<Department> deptRepo;
        GenaricReposatry<Student> StudentRepo;
        public ITIContext db;

        public UnitOfWork(ITIContext db)
        {
            this.db = db;
        }

        public GenaricReposatry<Department> DeptRepo
        {
            get
            {
                if (deptRepo == null)
                    deptRepo = new GenaricReposatry<Department>(db);

                return deptRepo;
            }
        }


        public GenaricReposatry<Student> studentRepo
        {
            get {
                if (StudentRepo == null)
                    StudentRepo = new GenaricReposatry<Student>(db);
                return StudentRepo;
            }
        }

        public int Save()
        {
            
            return db.SaveChanges();
        }
    }
}
