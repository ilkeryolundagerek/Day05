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
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DbContext context) : base(context)
        {
        }

        public override async Task<Item?> ReadOneAsync(object entityKey)
        {
            return await _set.Include(p => p.Person).FirstOrDefaultAsync(x => x.Id == (int)entityKey);
        }

        public override async Task<IEnumerable<Item>> ReadManyAsync(Expression<Func<Item, bool>>? predicate = null)
        {
            return predicate != null ? _set.Include(p => p.Person).Where(predicate) : _set.Include(p => p.Person);
        }
    }
}
