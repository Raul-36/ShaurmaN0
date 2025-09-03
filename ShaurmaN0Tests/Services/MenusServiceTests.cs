using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShaurmaN0App.Repositories.Base;
using ShaurmaN0App.Services.Base;
using ShaurmaN0App.Models;

public class MenusServiceTests
{
    [Theory]
    [InlineData("Pizza", true)]
    [InlineData("Burgers", true)]
    [InlineData("Sushi", false)]
    public async Task NameIsTaken_ReturnsExpectedResult(string nameToCheck, bool expected)
    {
        var mockRepo = new Mock<IMenusRepository>();
        mockRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Menus>
            {
                new Menus { Name = "Pizza" },
                new Menus { Name = "Burgers" }
            });

        var service = new MenusService(mockRepo.Object);

        var result = await service.NameIsTaken(nameToCheck);

        Assert.Equal(expected, result);
    }
}
