// using System.Net;

// public class ProductCalculatorIntegrationTests
//     : IClassFixture<WebApplicationFactory<Program>>
// {
//     private readonly HttpClient _client;

//     public ProductCalculatorIntegrationTests(
//         WebApplicationFactory<Program> factory)
//     {
//         _client = factory.CreateClient();
//     }

//     [Fact]
//     public async Task Calculate_ReturnsOk_WhenInputIsValid()
//     {
//         // Act
//         var response = await _client.GetAsync(
//             "/api/Test/calculate?price=100&discountPercentage=20");

//         // Assert
//         Assert.Equal(
//             HttpStatusCode.OK,
//             response.StatusCode);
//     }
// }