using Moq;
using Xunit;
using FluentValidation.TestHelper;
using System.Threading.Tasks;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;
using ShaurmaN0App.Validators;

public class MenusValidatorTests
{
    [Theory]
    [InlineData("", false, "Name cannot be empty.")]     
    [InlineData("Pizza", true, "Name is already taken.")]
    [InlineData("Sushi", false, null)]                   
    public async Task NameValidation_WorksAsExpected(string name, bool isTaken, string expectedError)
    {
        var serviceMock = new Mock<IMenusService>();
        serviceMock.Setup(s => s.NameIsTaken(name)).ReturnsAsync(isTaken);

        var validator = new MenusValidator(serviceMock.Object);

        var menu = new Menus { Name = name };

        var result = await validator.TestValidateAsync(menu);

        if (expectedError != null)
        {
            result.ShouldHaveValidationErrorFor(m => m.Name)
                  .WithErrorMessage(expectedError);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(m => m.Name);
        }
    }
}
