using Engine;
using IServices;

namespace Services;

public sealed class TestService : ITestService
{
    private readonly ITestEngine _engine;

    public TestService(ITestEngine engine)
    {
        this._engine = engine;
    }

    public async Task<string> Test(string testMessage)
    {
        return await this._engine.Test(testMessage);
    }
}