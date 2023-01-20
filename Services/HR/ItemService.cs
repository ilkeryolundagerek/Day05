using Core;
using Core.DTOs;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.HR
{
    public class ItemService : IItemService
    {
        private IUnitOfWork uow;
        public ItemService(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public async Task<IEnumerable<ItemDTO>> GetAll()
        {
            return from i in await uow.Items.ReadManyAsync()
                   select new ItemDTO
                   {
                       Id = i.Id,
                       Name = i.Name,
                       Category = i.Category,
                       PersonFullname = $"{i.Person.Firstname} {i.Person.Middlename} {i.Person.Lastname}",
                       PersonId = i.PersonId
                   };
        }

        public async Task<ItemDTO?> GetOne(int id)
        {
            var i = await uow.Items.ReadOneAsync(id);
            return new ItemDTO
            {
                Id = i.Id,
                Name = i.Name,
                Category = i.Category,
                PersonFullname = $"{i.Person.Firstname} {i.Person.Middlename} {i.Person.Lastname}",
                PersonId = i.PersonId
            };
        }
    }
}
