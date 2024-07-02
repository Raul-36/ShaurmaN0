using System;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShaurmaN0App.Dtos;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;
using ShaurmaN0App.Services.Base;
namespace ShaurmaN0App.Controllers;


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

        [ActionName("AddMenusApi")]
        [HttpPost]
        public async Task<IActionResult> AddMenusApi([FromForm] MenusCreateDto menusCreateDto)
        {
                foreach (var menu in menusCreateDto.Categories)
                {
                        Console.WriteLine(menu.Text);
                }
                Menus menus = new Menus()
                {
                        Name = menusCreateDto.Name,
                        Price = menusCreateDto.Price,
                        MenusCategoryId = menusCreateDto.SelectedCategoryId
                };
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
                return base.Redirect("GetAll");
        }
        [ActionName("AddMenus")]
        [HttpGet]
        public async Task<IActionResult> AddMenusAsync()
        {

                var model = new MenusCreateDto
                {
                        Categories = await this.GetSelectListItemsCategoriesAsync()
                };

                return View(model);
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