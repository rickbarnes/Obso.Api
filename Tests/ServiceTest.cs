using System.Threading.Tasks;
using Services;
using Xunit;

namespace Tests;

public sealed class ServiceTest
{
    [Fact]
    public async Task Should_Return_Test_Message()
    {
        // Arrange
        var testMessage = "Hello World";
        var expected = $"You said {testMessage}";
        
        var service = new TestService(ServiceMockHelper.CreateTestEngine());
        
        // Act
        var actual = await service.Test(testMessage);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Should_Not_Return_Incorrect_Message()
    {
        // Arrange
        var testMessage = "Hello World";
        var expected = $"You did not say {testMessage}";
        
        var service = new TestService(ServiceMockHelper.CreateTestEngine());
        
        // Act
        var actual = await service.Test(testMessage);
        
        // Assert
        Assert.NotEqual(expected, actual);
    }
}