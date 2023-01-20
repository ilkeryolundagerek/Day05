using Core;
using Core.Repositories;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private IPersonRepository people;
        private IDepartmentRepository departments;

        public UnitOfWork(DbContext _context)
        {
            context = _context;
        }

        public IPersonRepository People => people = people ?? new PersonRepository();

        public IDepartmentRepository Departments => departments = departments ?? new DepartmentRepository();

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
