using Core.DTOs;
using Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonListItemDTO>> GetPeopleAsync();
        IEnumerable<PersonListItemDTO> GetPeople();
        Task<PersonDetailDTO?> GetPersonDetailAsync(int id);
        PersonDetailDTO? GetPersonDetail(int id);
        IEnumerable<DepartmentDTO> GetDepartments();
        void Update(PersonDetailDTO person);
        void Add(PersonDetailDTO person);
    }
}
