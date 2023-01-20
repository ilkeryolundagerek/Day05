using Core.DTOs;
using Core.Services;

namespace Services.HR
{
    public class DepartmentService : IDepartmentService
    {
        public Task<IEnumerable<DepartmentDTO>> GetAllDepartmentWithPeopleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
