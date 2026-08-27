// public class ProductCalculatorTests
// {
//     [Fact]
//     public void CalculateFinalPrice_ReturnsCorrectPrice()
//     {
//         // Arrange
//         var calculator = new ProductCalculator();

//         // Act
//         var result = calculator.CalculateFinalPrice(100m, 20);

//         // Assert
//         Assert.Equal(80m, result);
//     }

//     [Fact]
//     public void CalculateFinalPrice_ThrowsException_WhenPriceIsNegative()
//     {
//         // Arrange
//         var calculator = new ProductCalculator();

//         // Act & Assert
//         Assert.Throws<ArgumentException>(
//             () => calculator.CalculateFinalPrice(-100m, 20));
//     }

//     [Fact]
//     public void CalculateFinalPrice_ThrowsException_WhenDiscountIsInvalid()
//     {
//         // Arrange
//         var calculator = new ProductCalculator();

//         // Act & Assert
//         Assert.Throws<ArgumentException>(
//             () => calculator.CalculateFinalPrice(100m, 150));
//     }
// }
