namespace ShaurmaN0.Controllers;

using System.Net;
using ShaurmaN0.Attributes.Http;
using ShaurmaN0.Controllers.Base;

public class HomeController : ControllerBase
{
    [HttpGet]
    public async Task Index() {
        await WriteViewAsync("index");
    }
}