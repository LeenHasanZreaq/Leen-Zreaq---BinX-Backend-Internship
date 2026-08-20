using Moq;
using OrderService;

namespace OrderService.Tests;

public class OrderServiceTests
{
    [Fact]
    public async Task GetOrderTotalAsync_ReturnsOrderTotal()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();

        mockRepo
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Order
            {
                Id = 1,
                Total = 99.99m
            });

        var service = new OrderService(mockRepo.Object);

        // Act
        var result = await service.GetOrderTotalAsync(1);

        // Assert
        Assert.Equal(99.99m, result);
    }

    [Fact]
    public async Task GetOrderTotalAsync_ThrowsException_WhenRepositoryFails()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();

        mockRepo
            .Setup(r => r.GetByIdAsync(1))
            .ThrowsAsync(new InvalidOperationException("Database error"));

        var service = new OrderService(mockRepo.Object);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(
            () => service.GetOrderTotalAsync(1)
        );
    }

    [Fact]
    public async Task GetOrderTotalAsync_CallsRepositoryExactlyOnce()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();

        mockRepo
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Order
            {
                Id = 1,
                Total = 50m
            });

        var service = new OrderService(mockRepo.Object);

        // Act
        await service.GetOrderTotalAsync(1);

        // Assert
        mockRepo.Verify(
            r => r.GetByIdAsync(1),
            Times.Once
        );
    }
}