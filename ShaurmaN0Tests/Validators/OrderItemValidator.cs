using Moq;
using Xunit;
using FluentValidation.TestHelper;
using System;
using System.Threading.Tasks;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;
using ShaurmaN0App.Validators;

public class OrderItemValidatorTests
{
    [Theory]
    // name: Count, Menu exists?, Menu price, Total, expected error property, expected message
    [InlineData(0, true, 10, 0, "Count", "Count must be greater than zero.")]
    [InlineData(21, true, 10, 210, "Count", "Count must be less than or equal to 20.")]
    [InlineData(2, false, 0, 20, "MenusId", "Menus does not exist.")]
    [InlineData(2, true, 10, 25, "Total", "Invalid Total.")]
    public async Task Validate_OrderItem_ReturnsExpectedError(
        int count,
        bool menuExists,
        double menuPrice,
        double total,
        string expectedErrorProperty,
        string expectedErrorMessage)
    {
        var serviceMock = new Mock<IMenusService>();
        serviceMock.Setup(s => s.GetByIdAsync(It.IsAny<Guid>()))
                   .ReturnsAsync(menuExists ? new Menus { Price = menuPrice } : null);

        var validator = new OrderItemValidator(serviceMock.Object);

        var orderItem = new OrderItem { Count = count, MenusId = Guid.NewGuid(), Total = total };

        var result = await validator.TestValidateAsync(orderItem);

        if (expectedErrorMessage != null)
        {
            result.ShouldHaveValidationErrorFor(expectedErrorProperty)
                  .WithErrorMessage(expectedErrorMessage);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(i => i.Count);
            result.ShouldNotHaveValidationErrorFor(i => i.MenusId);
            result.ShouldNotHaveValidationErrorFor(i => i.Total);
        }
    }
}
