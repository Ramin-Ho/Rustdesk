namespace RustDeskEnterprise.Tests.Shared;

/// <summary>
/// تست‌های Exception‌های Shared
Unit tests for Shared exceptions
/// </summary>
public class SharedExceptionsTests
{
    [Fact]
    public void ConfigurationException_ShouldInitializeWithMessage()
    {
        // Act
        var exception = new ConfigurationException("Test message");

        // Assert
        Assert.Equal("Test message", exception.Message);
    }

    [Fact]
    public void ConfigurationException_ShouldInitializeWithMessageAndInnerException()
    {
        // Arrange
        var innerException = new Exception("Inner exception");

        // Act
        var exception = new ConfigurationException("Test message", innerException);

        // Assert
        Assert.Equal("Test message", exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }

    [Fact]
    public void UpdateException_ShouldInitializeWithMessage()
    {
        // Act
        var exception = new UpdateException("Test message");

        // Assert
        Assert.Equal("Test message", exception.Message);
    }

    [Fact]
    public void UpdateException_ShouldInitializeWithMessageAndInnerException()
    {
        // Arrange
        var innerException = new Exception("Inner exception");

        // Act
        var exception = new UpdateException("Test message", innerException);

        // Assert
        Assert.Equal("Test message", exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}
