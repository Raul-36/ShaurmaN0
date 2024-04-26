using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ShaurmaN0App.Models;
namespace ShaurmaN0App.Controllers;


[Route("[controller]/[action]")]
class MenuItemController : Controller
{
        [ActionName("Info")]
        public async Task<IActionResult> GetMenuItemAsync() {
        var MenuItemJson = await System.IO.File.ReadAllTextAsync("./Assets/MenuItem.json");
        var MenuItem = JsonSerializer.Deserialize<MenuItem>(MenuItemJson);
        return base.View(model: MenuItem);
        }
}