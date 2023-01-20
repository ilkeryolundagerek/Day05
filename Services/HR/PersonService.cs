using Core.DTOs;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.HR
{
    public class PersonService : IPersonService
    {
        public Task<IEnumerable<PersonListItemDTO>> GetPeopleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonDetailDTO>> GetPersonDetailAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class DepartmentService : IDepartmentService
    {
        public Task<IEnumerable<DepartmentDTO>> GetAllDepartmentWithPeopleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
