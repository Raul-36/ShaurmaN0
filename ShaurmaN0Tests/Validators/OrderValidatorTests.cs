using Moq;
using Xunit;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;
using ShaurmaN0App.Validators;

public class OrderValidatorTests
{
    private OrderValidator CreateValidator()
    {
        var menusServiceMock = new Mock<IMenusService>();
        menusServiceMock.Setup(s => s.GetByIdAsync(It.IsAny<Guid>()))
                        .ReturnsAsync(new Menus { Price = 10 });

        var orderItemValidator = new OrderItemValidator(menusServiceMock.Object);

        var orderServiceMock = new Mock<IOrderService>();

        return new OrderValidator(orderServiceMock.Object, orderItemValidator);
    }

    [Theory]
    [MemberData(nameof(GetOrdersForValidation))]
    public async Task Validate_Order_ReturnsExpectedError(Order order, string? expectedErrorProperty, string? expectedErrorMessage)
    {
        var validator = CreateValidator();

        var result = await validator.TestValidateAsync(order);

        if (!string.IsNullOrEmpty(expectedErrorProperty))
        {
            result.ShouldHaveValidationErrorFor(expectedErrorProperty)
                  .WithErrorMessage(expectedErrorMessage);
        }
        else
        {
            // Все валидные кейсы
            result.ShouldNotHaveValidationErrorFor(o => o.Date);
            result.ShouldNotHaveValidationErrorFor(o => o.OrderItems);
            result.ShouldNotHaveValidationErrorFor(o => o.Total);
        }
    }

    public static IEnumerable<object[]> GetOrdersForValidation()
    {
        // 1. empty Date 
        yield return new object[]
        {
            new Order
            {
                Date = default,
                OrderItems = new List<OrderItem> { new OrderItem { Count = 1, MenusId = Guid.NewGuid(), Total = 10 } },
                Total = 10
            },
            "Date",
            "Date is required."
        };

        // 2. empty OrderItems
        yield return new object[]
        {
            new Order
            {
                Date = DateTime.Now,
                OrderItems = new List<OrderItem>(),
                Total = 0
            },
            "OrderItems",
            "Order must have at least one item."
        };

        // 3. Total != sum of every(OrderItems.Count * Menu.Price)
        yield return new object[]
        {
            new Order
            {
                Date = DateTime.Now,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { Count = 2, MenusId = Guid.NewGuid(), Total = 10 },
                    new OrderItem { Count = 1, MenusId = Guid.NewGuid(), Total = 5 }
                },
                Total = 20 
            },
            "Total",
            "Total does not match sum of order items."
        };

        // 4. Valid order
        yield return new object[]
        {
            new Order
            {
                Date = DateTime.Now,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { Count = 2, MenusId = Guid.NewGuid(), Total = 10 },
                    new OrderItem { Count = 1, MenusId = Guid.NewGuid(), Total = 5 }
                },
                Total = 15
            },
            null,
            null
        };
    }
}