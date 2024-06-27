using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Controllers
{
    [Route("/[controller]/[action]")]
    public class MenusCategoryController : Controller
    {
        private readonly IMenusCategoryRepository menusCategoryRepository;
        public MenusCategoryController(IMenusCategoryRepository menusCategoryRepository)
        {
            this.menusCategoryRepository = menusCategoryRepository;
        }
        [ActionName("GetAll")]
        public async Task<IActionResult> GetCategorysAsync()
        {
            var menus = await menusCategoryRepository.GetAllAsync();
            return base.View(model: menus);
        }

        [ActionName("AddCategoryApi")]
        [HttpPost]
        public async Task<IActionResult> AddCategoryApi([FromForm] MenusCategory menusCategory)
        {
            await this.menusCategoryRepository.CreateAsync(menusCategory);
            return base.Redirect("GetAll");
        }
        [ActionName("AddCategory")]
        [HttpGet]
        public async Task<IActionResult> AddCategoryAsync()
        {
            return base.View(model: new MenusCategory { });
        }
        [ActionName("EditCategoryApi")]
        [HttpPut]
        public async Task<IActionResult> EditCategoryApi([FromBody] MenusCategory menusCategory)
        {
            await this.menusCategoryRepository.UpdateAsync(menusCategory);
            return base.Redirect("GetAll");
        }
        [Route("/[controller]/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditCategoryAsync(Guid id)
        {
            return base.View(model:  await menusCategoryRepository.GetByIdAsync(id));
        }
        [Route("/[controller]/DeleteApi/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteApiAsync(Guid id)
        {
            Console.WriteLine(id);
            await this.menusCategoryRepository.DeleteAsync(id);
            return base.Redirect("GetAll");
        }


    }
}
