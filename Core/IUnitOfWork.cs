using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Interface yapsıı abstract (soyut) olduğundan sadece get metodu bulundurur.
        IPersonRepository People { get; }
        IDepartmentRepository Departments { get; }
        IItemRepository Items{ get; }
        void Commit();
        Task CommitAsync();
    }
}
