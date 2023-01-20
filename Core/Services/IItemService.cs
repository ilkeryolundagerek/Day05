using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetAll();
        Task<ItemDTO?> GetOne(int id);
    }
}
