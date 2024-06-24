using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;
namespace ShaurmaN0App.Controllers;


[Route("/[controller]/[action]")]
public class MenusController : Controller
{
        private readonly IMenusRepository menusRepository;
        public MenusController(IMenusRepository menusRepository)
        {
                this.menusRepository = menusRepository;
        }
        [ActionName("GetAll")]
        public async Task<IActionResult> GetMenusAsync()
        {
                var menus = await menusRepository.GetAllAsync();
                return base.View(model: menus);
        }

        [ActionName("AddMenusApi")]
        [HttpPost]
        public async Task<IActionResult> AddMenusApi([FromForm] Menus menus)
        {
                await this.menusRepository.CreateAsync(menus);
                return base.Redirect("GetAll");
        }
        [ActionName("AddMenus")]
        [HttpGet]
        public async Task<IActionResult> AddMenusAsync()
        {
                return base.View(model: new Menus { });
        }

}