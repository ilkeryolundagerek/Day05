using Core.DTOs;

namespace Core.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentWithPeopleAsync();
    }
}
