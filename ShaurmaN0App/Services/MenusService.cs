using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Services.Base
{
    public class MenusService : IMenusService
    {
        private readonly IMenusRepository repository;
        public MenusService(IMenusRepository repository)
        {
            this.repository = repository;
        }
        public async Task CreateAsync(Menus menus)
        {
            await repository.CreateAsync(menus);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Menus>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public async Task<Menus> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> NameIsTaken(string name)
        {
            var names = (await this.GetAllAsync()).Select(m => m.Name).ToList();
            if (names.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Menus menus)
        {
            await repository.UpdateAsync(menus);
        }
        public async Task<IEnumerable<Menus>> GetAllByCategoryAsync(Guid menusCategoryId)
        {
            return (await this.GetAllAsync())
            .Where(m => m.MenusCategoryId == menusCategoryId);
        }
        
    }
}