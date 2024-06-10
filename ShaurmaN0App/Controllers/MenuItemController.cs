using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ShaurmaN0App.Models;
namespace ShaurmaN0App.Controllers;


[Route("/[controller]/[action]")]
public class MenuItemController : Controller
{
        [ActionName("MenuItems")]
        public async Task<IActionResult> GetMenuItemsAsync() {
        var menuItemsJson = await System.IO.File.ReadAllTextAsync("./Assets/MenuItem.json");
        var menuItems = JsonSerializer.Deserialize<IEnumerable<MenuItem>>(menuItemsJson, new JsonSerializerOptions
        {
                PropertyNameCaseInsensitive = true
        });
        return base.View(model: menuItems);
        }

        [ActionName("AddMenuItemApi")]
        [HttpPost]
        public async Task<IActionResult> AddMenuItemApi([FromForm] MenuItem menuItem) { 
                var menuItemsJson = await System.IO.File.ReadAllTextAsync("./Assets/MenuItem.json");
                var menuItems = JsonSerializer.Deserialize<IEnumerable<MenuItem>>(menuItemsJson, new JsonSerializerOptions
                {
                        PropertyNameCaseInsensitive = true
                });

                var newMenuItems = menuItems.Append(menuItem);
                System.IO.File.WriteAllText("./Assets/MenuItem.json", JsonSerializer.Serialize(newMenuItems));
                return base.Redirect("MenuItems");
        }
        [ActionName("AddMenuItem")]
        [HttpGet]
        public async Task<IActionResult> AddMenuItem() {
                return base.View(model: new MenuItem {});
        }

}