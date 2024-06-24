using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ShaurmaN0App.Models;
namespace ShaurmaN0App.Controllers;


[Route("/[controller]/[action]")]
public class MenusController : Controller
{
        [ActionName("Menus")]
        public async Task<IActionResult> GetMenusAsync() {
        var menusJson = await System.IO.File.ReadAllTextAsync("./Assets/Menus.json");
        var menus = JsonSerializer.Deserialize<IEnumerable<Menus>>(menusJson, new JsonSerializerOptions
        {
                PropertyNameCaseInsensitive = true
        });
        return base.View(model: menus);
        }

        [ActionName("AddMenusApi")]
        [HttpPost]
        public async Task<IActionResult> AddMenusApi([FromForm] Menus menus) { 
                var menusJson = await System.IO.File.ReadAllTextAsync("./Assets/Menus.json");
                var menus = JsonSerializer.Deserialize<IEnumerable<Menus>>(menusJson, new JsonSerializerOptions
                {
                        PropertyNameCaseInsensitive = true
                });

                var newMenus = menus.Append(menus);
                System.IO.File.WriteAllText("./Assets/Menus.json", JsonSerializer.Serialize(newMenus));
                return base.Redirect("Menus");
        }
        [ActionName("AddMenus")]
        [HttpGet]
        public async Task<IActionResult> AddMenus() {
                return base.View(model: new Menus {});
        }

}