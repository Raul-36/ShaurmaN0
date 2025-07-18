using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;
using ShaurmaN0App.Services.Base;

namespace ShaurmaN0App.Controllers
{
    [Route("/[controller]/[action]")]
    public class MenusCategoryController : Controller
    {
        private readonly IMenusCategoryService menusCategoryService;
        private readonly IValidator<MenusCategory> menusCategoryValidator;
        public MenusCategoryController(IMenusCategoryService menusCategoryService, IValidator<MenusCategory> menusCategoryValidator)
        {
            this.menusCategoryService = menusCategoryService;
            this.menusCategoryValidator = menusCategoryValidator;
        }
        [ActionName("GetAll")]
        public async Task<IActionResult> GetCategorysAsync()
        {
            var menus = await menusCategoryService.GetAllAsync();
            return base.View(model: menus);
        }

        [ActionName("AddCategoryApi")]
        [HttpPost]
        public async Task<IActionResult> AddCategoryApi([FromForm] MenusCategory menusCategory)
        {
            var validationResult = await menusCategoryValidator.ValidateAsync(menusCategory);

            if (validationResult.IsValid == false)
            {

                foreach (var error in validationResult.Errors)
                {
                    base.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return base.View("AddCategory");
            }
            await this.menusCategoryService.CreateAsync(menusCategory);
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
            var validationResult = await menusCategoryValidator.ValidateAsync(menusCategory);

            if (validationResult.IsValid == false)
            {

                foreach (var error in validationResult.Errors)
                {
                    base.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return base.View($"EditCategory",menusCategory);
            }
            await this.menusCategoryService.UpdateAsync(menusCategory);
            return base.Redirect("GetAll");
        }
        [Route("/[controller]/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditCategoryAsync(Guid id)
        {
            return base.View(model: await menusCategoryService.GetByIdAsync(id));
        }
        [Route("/[controller]/DeleteApi/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteApiAsync(Guid id)
        {
            await this.menusCategoryService.DeleteAsync(id);
            return base.Redirect("GetAll");
        }


    }
}
