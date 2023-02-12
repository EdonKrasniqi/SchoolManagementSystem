using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Departament>
    {
        void Update(Departament obj);
    }
}
