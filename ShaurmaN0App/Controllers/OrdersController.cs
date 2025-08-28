using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;

namespace ShaurmaN0App.Controllers;

//[Authorize]
[Route("/[controller]/[action]")]
public class OrdersController : Controller
{
    private readonly IOrderService orderService;
    private readonly IValidator<Order> orderValidator;

    public OrdersController(IOrderService orderService, IValidator<Order> orderValidator)
    {
        this.orderService = orderService;
        this.orderValidator = orderValidator;
    }

    [ActionName("GetAll")]
    //[Authorize (Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        var orders = await orderService.GetAllAsync();
        return base.View(model: orders);
    }
    
    [ActionName("AddOrderApi")]
    [HttpPost]
    public async Task<IActionResult> AddOrderApi([FromForm] Order order)
    {
        var validationResult = await orderValidator.ValidateAsync(order);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                base.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return base.View("AddOrder", order);
        }

        await this.orderService.CreateAsync(order);
        return base.RedirectToAction("GetAll");
    }
}