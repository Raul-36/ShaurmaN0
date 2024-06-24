using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Models;

namespace ShaurmaN0App.Repositories.Base;
    public interface IMenusCategoryRepository{
        Task<IEnumerable<MenusCategory>> GetAllAsync();
        Task CreateAsync(MenusCategory menusCategory);
        Task UpdateAsync(MenusCategory menusCategory);
        Task DeleteAsync(Guid id);

    }
