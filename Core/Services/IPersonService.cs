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
        Task<IEnumerable<PersonDetailDTO>> GetPersonDetailAsync(int id);
    }
}
