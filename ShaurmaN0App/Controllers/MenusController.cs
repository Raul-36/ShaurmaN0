using System;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShaurmaN0App.Dtos;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;
using ShaurmaN0App.Services.Base;
namespace ShaurmaN0App.Controllers;

[Authorize]
[Route("/[controller]/[action]")]
public class MenusController : Controller
{
        private readonly IMenusService menusService;
        private readonly IMenusCategoryService categoryService;
        private readonly IValidator<Menus> menusValidator;
        public MenusController(IMenusService menusService, IMenusCategoryService categoryService, IValidator<Menus> menusValidator)
        {
                this.menusService = menusService;
                this.categoryService = categoryService;
                this.menusValidator = menusValidator;
        }
        [ActionName("GetAll")]
        public async Task<IActionResult> GetMenusAsync()
        {
                var menus = await menusService.GetAllAsync();
                return base.View(model: menus);
        }
        [Route("/[controller]/GetAll/ByCategory/{menusCategoryId}")]
        public async Task<IActionResult> GetMenusByCategoryAsync(Guid menusCategoryId)
        {
                var menus = await menusService.GetAllByCategoryAsync(menusCategoryId);
                if (menus == null || !menus.Any())
                {
                        return NotFound("No menus found for the specified category.");
                }
                return base.View("GetAll",model: menus);
        }

        [ActionName("AddMenusApi")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddMenusApi([FromForm] MenusCreateDto menusCreateDto, IFormFile menusImg)
        {
                var newMenusId = Guid.NewGuid();
                Menus menus = new Menus()
                {
                        Id = newMenusId,
                        Name = menusCreateDto.Name,
                        Price = menusCreateDto.Price,
                        MenusCategoryId = menusCreateDto.SelectedCategoryId
                };
                if (!menusImg.ContentType.Equals("image/jpeg", StringComparison.OrdinalIgnoreCase))
                {
                        menusCreateDto.Categories = await this.GetSelectListItemsCategoriesAsync();
                        base.ModelState.AddModelError("menusImg", "The extension of the submitted file must be 'jpg'");
                        return base.View("AddMenus", menusCreateDto);
                }

                var validationResult = await menusValidator.ValidateAsync(menus);
                if (validationResult.IsValid == false)
                {

                        foreach (var error in validationResult.Errors)
                        {
                                base.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                        }
                        menusCreateDto.Categories = await this.GetSelectListItemsCategoriesAsync();
                        return base.View("AddMenus", menusCreateDto);
                }

                await this.menusService.CreateAsync(menus);

                using var newFileStream = System.IO.File.Create($"wwwroot/{newMenusId}.jpg");
                await menusImg.CopyToAsync(newFileStream);

                return base.Redirect("GetAll");
        }
        [ActionName("AddMenus")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddMenusAsync()
        {

                var model = new MenusCreateDto
                {
                        Categories = await this.GetSelectListItemsCategoriesAsync()
                };

                return View(model);
        }
        [ActionName("EditMenusApi")]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> EditApi([FromBody] Menus menus)
        {
                var validationResult = await menusValidator.ValidateAsync(menus);

                if (validationResult.IsValid == false)
                {

                        foreach (var error in validationResult.Errors)
                        {
                                base.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                        }
                        return base.View($"Edit", menus);
                }
                await this.menusService.UpdateAsync(menus);
                return base.Redirect("GetAll");
        }
        [Route("/[controller]/Edit/{id}")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
                return base.View(model: await menusService.GetByIdAsync(id));
        }
        [Route("/[controller]/DeleteApi/{id}")]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteApiAsync(Guid id)
        {
                await this.menusService.DeleteAsync(id);
                return base.Redirect("GetAll");
        }
        private async Task<IEnumerable<SelectListItem>> GetSelectListItemsCategoriesAsync()
        {

                var categories = await this.categoryService.GetAllAsync();
                var selectListCategories = categories
                .Select(c => new SelectListItem
                {
                        Value = c.Id.ToString(),
                        Text = c.Name
                });
                return selectListCategories.ToArray();
        }
}