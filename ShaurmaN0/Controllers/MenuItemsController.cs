using ShaurmaN0.Attributes.Http;
using ShaurmaN0.Controllers.Base;
using ShaurmaN0.Extensions;
using ShaurmaN0.Models;
using ShaurmaN0.Repositories;

namespace ShaurmaN0.Controllers;

public class MenuItemsController : ControllerBase
{
    private readonly MenuItemSqlRepository MenuItemSqlRepository;

    public MenuItemsController()
    {
        this.MenuItemSqlRepository = new MenuItemSqlRepository();
    }

    // GET: "/MenuItems/GetAllMenuItems"
    [HttpGet(ActionName = "GetAll")]
    public async Task GetAllMenuItemsAsync() {
        var MenuItems = await this.MenuItemSqlRepository.GetAllMenuItemsAsync();
        
        if(MenuItems is not null && MenuItems.Any()) {
            var html = MenuItems.AsHtml();
            await base.LayoutAsync(html);
        }
        else {
            await new ErrorController().NotFound(nameof(MenuItems));
        }
    }
}