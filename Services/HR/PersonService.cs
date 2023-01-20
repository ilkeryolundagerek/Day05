using Core;
using Core.DTOs;
using Core.Services;
using Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.HR
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork uow;
        public PersonService(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public async Task<IEnumerable<PersonListItemDTO>> GetPeopleAsync()
        {
            return from p in await uow.People.ReadManyAsync()
                   select new PersonListItemDTO
                   {
                       Id = p.Id,
                       Firstname = p.Firstname,
                       Middlename = p.Middlename,
                       Lastname = p.Lastname,
                       Email = p.Email,
                       DepartmentId = p.DepartmentId,
                       DepartmentName = p.Department.Name
                   };
        }

        public async Task<PersonDetailDTO?> GetPersonDetailAsync(int id)
        {
            var p = await uow.People.ReadOneAsync(id);
            return p != null ? new PersonDetailDTO
            {
                Id = p.Id,
                Firstname = p.Firstname,
                Middlename = p.Middlename,
                Lastname = p.Lastname,
                Email = p.Email,
                DepartmentId = p.DepartmentId,
                DepartmentName = p.Department.Name,
                DepartmentDescription = p.Department.Description,
                Address = p.Address,
                City = p.City,
                PersonType = p.PersonType,
                Phone = p.Phone
            } : null;
        }
    }
}
