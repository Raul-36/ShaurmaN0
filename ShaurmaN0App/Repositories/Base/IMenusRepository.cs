using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Models;

namespace ShaurmaN0App.Repositories.Base
{
    public interface IMenusRepository
    {
        Task<IEnumerable<Menus>> GetAllAsync();
        Task CreateAsync(Menus menus);
        Task UpdateAsync(Menus menus);
        Task DeleteAsync(Guid id);
    }
}