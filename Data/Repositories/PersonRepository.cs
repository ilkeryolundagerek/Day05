using Core.EntityModels;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UtilitiesCore;

namespace Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(CRMContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Person>> ReadManyAsync(Expression<Func<Person, bool>>? predicate = null)
        {
            return predicate != null ? _set.Include(d => d.Department).Where(predicate) : _set.Include(d => d.Department);
        }

        public override async Task<Person?> ReadOneAsync(object entityKey)
        {
            return await _set.Include(d => d.Department).FirstOrDefaultAsync(x => x.Id == (int)entityKey);
        }

        public async Task<IEnumerable<Person>> GetAllPeopleWithDepartmentAsync()
        {
            return await ReadManyAsync();
        }
    }
}
