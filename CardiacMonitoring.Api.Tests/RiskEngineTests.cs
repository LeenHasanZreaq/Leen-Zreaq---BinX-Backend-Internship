using CardiacMonitoring.Api.Domain;
using CardiacMonitoring.Api.Services;

namespace CardiacMonitoring.Api.Tests;

public class RiskEngineTests
{
    // FACT 1
    [Fact]
    public void Evaluate_ReturnsNormal_WhenHeartRateIsNormal()
    {
        // Arrange
        var engine = new RiskEngine();

        var vital = new VitalSign
        {
            HeartRate = 80
        };

        // Act
        var result = engine.Evaluate(vital);

        // Assert
        Assert.Equal(RiskLevel.Normal, result);
    }

    // FACT 2
    [Fact]
    public void Evaluate_ReturnsWarning_WhenHeartRateIsLow()
    {
        // Arrange
        var engine = new RiskEngine();

        var vital = new VitalSign
        {
            HeartRate = 50
        };

        // Act
        var result = engine.Evaluate(vital);

        // Assert
        Assert.Equal(RiskLevel.Warning, result);
    }

    // FACT 3
    [Fact]
    public void Evaluate_ReturnsCritical_WhenHeartRateIsVeryHigh()
    {
        // Arrange
        var engine = new RiskEngine();

        var vital = new VitalSign
        {
            HeartRate = 180
        };

        // Act
        var result = engine.Evaluate(vital);

        // Assert
        Assert.Equal(RiskLevel.Critical, result);
    }

    // THEORY
    [Theory]
    [InlineData(80, RiskLevel.Normal)]
    [InlineData(50, RiskLevel.Warning)]
    [InlineData(180, RiskLevel.Critical)]
    public void Evaluate_ReturnsExpectedRiskLevel(
        int heartRate,
        RiskLevel expectedRisk)
    {
        // Arrange
        var engine = new RiskEngine();

        var vital = new VitalSign
        {
            HeartRate = heartRate
        };

        // Act
        var result = engine.Evaluate(vital);

        // Assert
        Assert.Equal(expectedRisk, result);
    }
}
