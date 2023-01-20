using Core.EntityModels;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesCore;

namespace Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository() : base(new CRMContext())
        {
        }

        public async Task<IEnumerable<Person>> GetAllPeopleWithDepartmentAsync()
        {
            return await ReadManyAsync();
        }
    }

    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository() : base(new CRMContext())
        {
        }
    }
}
