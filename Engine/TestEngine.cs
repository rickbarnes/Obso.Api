using IRepository;

namespace Engine;

public sealed class TestEngine : ITestEngine
{
    private readonly ITestRepository _repository;

    public TestEngine(ITestRepository repository)
    {
        this._repository = repository;
    }
    
    public Task<string> Test(string testMessage)
    {
        return this._repository.Test(testMessage);
    }
}