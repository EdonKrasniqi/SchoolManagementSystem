using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            Department = new DepartmentRepository(_db);
        }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IDepartmentRepository Department { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
