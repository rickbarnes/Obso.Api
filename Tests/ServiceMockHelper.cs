using Engine;
using Moq;

namespace Tests;

internal static class ServiceMockHelper
{
   internal static ITestEngine CreateTestEngine()
   {
      var mock = new Mock<ITestEngine>();

      mock.Setup(x => x.Test(It.IsAny<string>())).ReturnsAsync((string testMessage) => $"You said {testMessage}");

      return mock.Object;
   } 
}