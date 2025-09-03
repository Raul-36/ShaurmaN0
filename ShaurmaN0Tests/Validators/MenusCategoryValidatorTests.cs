using Moq;
using Xunit;
using FluentValidation.TestHelper;
using System.Threading.Tasks;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;
using ShaurmaN0App.Validators;

public class MenusCategoryValidatorTests
{
    [Theory]
    [InlineData("", false, "Name cannot be empty.")]      
    [InlineData("Pizza", true, "Name is already taken.")] 
    [InlineData("Sushi", false, null)]                    
    public async Task NameValidation_WorksAsExpected(string name, bool isTaken, string expectedError)
    {
        var serviceMock = new Mock<IMenusCategoryService>();
        serviceMock.Setup(s => s.NameIsTaken(name)).ReturnsAsync(isTaken);

        var validator = new MenusCategoryValidator(serviceMock.Object);

        var category = new MenusCategory { Name = name };

        var result = await validator.TestValidateAsync(category);

        if (expectedError != null)
        {
            result.ShouldHaveValidationErrorFor(c => c.Name)
                  .WithErrorMessage(expectedError);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(c => c.Name);
        }
    }
}
