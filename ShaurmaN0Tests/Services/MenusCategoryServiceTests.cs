using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShaurmaN0App.Services.Base;
using ShaurmaN0App.Models;
using ShaurmaN0App.Repositories.Base;

public class MenusCategoryServiceTests
{
    [Theory]
    [InlineData("Food", true)]
    [InlineData("drinkables", true)]
    [InlineData("Sushi", false)]
    public async Task NameIsTaken_ReturnsExpectedResult(string nameToCheck, bool expected)
    {
        var mockRepo = new Mock<IMenusCategoryRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<MenusCategory>
            {
                new MenusCategory { Name = "Food" },
                new MenusCategory { Name = "drinkables" }
            });

        var service = new MenusCategoryService(mockRepo.Object);

        var result = await service.NameIsTaken(nameToCheck);

        Assert.Equal(expected, result);
    }
}
