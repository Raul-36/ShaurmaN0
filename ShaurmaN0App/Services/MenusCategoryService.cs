using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Services.Base
{
    public class MenusCategoryService : IMenusCategoryService
    {
        private readonly IMenusCategoryRepository repository;
        public MenusCategoryService(IMenusCategoryRepository repository)
        {
            this.repository = repository;
        }
        public async Task CreateAsync(MenusCategory menusCategory)
        {
            await repository.CreateAsync(menusCategory);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public Task<IEnumerable<MenusCategory>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public async Task<MenusCategory> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> NameIsTaken(string name)
        {

            var names = new List<string>();
            foreach (var category in await this.GetAllAsync())
            {
                names.Add(category.Name);
            }
            foreach(var categoryName in names){
                if(name == categoryName){
                    return true;
                }
            }
            return false;
        }

        public async Task UpdateAsync(MenusCategory menusCategory)
        {
            await repository.UpdateAsync(menusCategory);
        }
    }
}