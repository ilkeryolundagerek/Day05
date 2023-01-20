using Core;
using Core.Repositories;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMContext context;
        private IPersonRepository people;
        private IDepartmentRepository departments;
        private IItemRepository items;
        public UnitOfWork(CRMContext _context)
        {
            context = _context;
        }

        public IPersonRepository People => people = people ?? new PersonRepository(context);

        public IDepartmentRepository Departments => departments = departments ?? new DepartmentRepository(context);

        public IItemRepository Items => items = items ?? new ItemRepository(context);

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
