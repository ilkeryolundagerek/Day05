using Core;
using Core.DTOs;
using Core.Services;
using Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Services.HR
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork uow;
        private IMapper _mapper;
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            _mapper = mapper;
        }

        public void Add(PersonDetailDTO p)
        {
            //if (p.Id == 0)
            //{
            var entity = _mapper.Map<Person>(p);

            /*new Person
        {
            Firstname = p.Firstname,
            Middlename = p.Middlename,
            Lastname = p.Lastname,
            Phone = p.Phone,
            Address = p.Address,
            City = p.City,
            DepartmentId = p.DepartmentId,
            Email = p.Email,
            PersonType = p.PersonType
        };*/
            uow.People.CreateOne(entity);
            //}
            //else
            //{
            //    //Güncelleme her zaman data kaybıdır, bu riske girmeyebilirsiniz.
            //    await Update(p);
            //}
            uow.Commit();
        }

        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            return from d in uow.Departments.ReadMany()
                   select _mapper.Map<DepartmentDTO>(d);

            //new DepartmentDTO
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    Description = d.Description
            //};
        }

        public async Task<IEnumerable<PersonListItemDTO>> GetPeopleAsync()
        {
            return from p in await uow.People.ReadManyAsync()
                   select _mapper.Map<PersonListItemDTO>(p);

            //new PersonListItemDTO
            //{
            //    Id = p.Id,
            //    Firstname = p.Firstname,
            //    Middlename = p.Middlename,
            //    Lastname = p.Lastname,
            //    Email = p.Email,
            //    DepartmentId = p.DepartmentId,
            //    DepartmentName = p.Department.Name
            //};
        }

        public IEnumerable<PersonListItemDTO> GetPeople()
        {
            return from p in uow.People.ReadMany()
                   select _mapper.Map<PersonListItemDTO>(p);
            //new PersonListItemDTO
            //{
            //    Id = p.Id,
            //    Firstname = p.Firstname,
            //    Middlename = p.Middlename,
            //    Lastname = p.Lastname,
            //    Email = p.Email,
            //    DepartmentId = p.DepartmentId,
            //    DepartmentName = p.Department.Name
            //};
        }

        public PersonDetailDTO? GetPersonDetail(int id)
        {
            var p = uow.People.ReadOne(id);
            return p != null ? _mapper.Map<PersonDetailDTO>(p) : null;

            //    new PersonDetailDTO
            //{
            //    Id = p.Id,
            //    Firstname = p.Firstname,
            //    Middlename = p.Middlename,
            //    Lastname = p.Lastname,
            //    Email = p.Email,
            //    DepartmentId = p.DepartmentId,
            //    DepartmentName = p.Department.Name,
            //    DepartmentDescription = p.Department.Description,
            //    Address = p.Address,
            //    City = p.City,
            //    PersonType = p.PersonType,
            //    Phone = p.Phone
            //}
        }

        public async Task<PersonDetailDTO?> GetPersonDetailAsync(int id)
        {
            var p = await uow.People.ReadOneAsync(id);
            return p != null ? _mapper.Map<PersonDetailDTO>(p) : null;

            //new PersonDetailDTO
            //{
            //    Id = p.Id,
            //    Firstname = p.Firstname,
            //    Middlename = p.Middlename,
            //    Lastname = p.Lastname,
            //    Email = p.Email,
            //    DepartmentId = p.DepartmentId,
            //    DepartmentName = p.Department.Name,
            //    DepartmentDescription = p.Department.Description,
            //    Address = p.Address,
            //    City = p.City,
            //    PersonType = p.PersonType,
            //    Phone = p.Phone
            //} : null;
        }

        public void Update(PersonDetailDTO p)
        {
            var entity = uow.People.ReadOne(p.Id);
            if (entity != null)
            {
                entity = _mapper.Map<Person>(p);
                //entity.Firstname = p.Firstname;
                //entity.Middlename = p.Middlename;
                //entity.Lastname = p.Lastname;
                //entity.Phone = p.Phone;
                //entity.Address = p.Address;
                //entity.City = p.City;
                //entity.DepartmentId = p.DepartmentId;
                //entity.Email = p.Email;
                //entity.PersonType = p.PersonType;
                uow.People.Update(entity);
                uow.Commit();
            }
            else
            {
                Add(p);
            }
        }
    }
}
