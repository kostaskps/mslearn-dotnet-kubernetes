using System;
using Microsoft.Extensions.Logging;
using backend.Controllers;
using Moq;
using Xunit;

namespace backend.tests;

public class ControllerTests
{
    private readonly Mock<ILogger<PizzaInfoController>> _mockLogger;
    //private readonly PizzaInfoController _controller;

    public ControllerTests()
    {
        _mockLogger = new Mock<ILogger<PizzaInfoController>>();
        //_controller = new PizzaInfoController(_mockLogger.Object);
    }

    [Fact]
    public void Get_ReturnsIEnumerable_WithPizzaMenuItems()
    {
        // Arrange
        var controller = new PizzaInfoController(_mockLogger.Object);        

        // Act
        var result = controller.Get();

        // Assert
        var menuItems = Assert.IsAssignableFrom<IEnumerable<PizzaInfo>>(result);
        Assert.Equal(6, menuItems.Count());
    }
}