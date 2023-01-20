using Core.EntityModels;
using Core.Repositories;
using UtilitiesCore;

namespace Data.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CRMContext context) : base(context)
        {
        }
    }
}
