using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
    internal class DepartmentRepository : Repository<Departament>, IDepartmentRepository
    {
        private ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Departament obj)
        {
            _db.Departaments.Update(obj);
        }
    }
}
