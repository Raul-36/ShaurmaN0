using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Dtos;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;

namespace ShaurmaN0App.Convertors;

public class OrderCreateDtoConvertor
{
    private readonly IMenusService menusService;
    public OrderCreateDtoConvertor(IMenusService menusService)
    {
        this.menusService = menusService;
    }
    public async Task<Order> ConvertToOrderAsync(OrderCreateDto dto)
    {
        var order = new Order
        {
            Date = DateTime.UtcNow
        };
        var orderItems = new List<OrderItem> ();
        foreach (var itemDto in dto.OrderItems)
        {
            var menu = await menusService.GetByIdAsync(itemDto.MenusId);
            if (menu == null)
                throw new Exception($"Menu with id {itemDto.MenusId} not found.");

            var orderItem = new OrderItem
            {
                MenusId = itemDto.MenusId,
                Count = itemDto.Count,
                Total = menu.Price * itemDto.Count
            };
            orderItems.Add(orderItem);
            order.Total += orderItem.Total;

        }
        order.OrderItems = orderItems;
        return order;
    }

}