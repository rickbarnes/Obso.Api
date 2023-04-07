using IRepository;

namespace Repository;

public sealed class TestRepository : ITestRepository
{
    public Task<string> Test(string testMessage)
    {
        return Task.FromResult($"You said {testMessage}");
    }
}