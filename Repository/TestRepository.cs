using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using IRepository;

namespace Repository;

public sealed class TestRepository : ITestRepository
{
    public TestRepository()
    {
    }

    public Task<string> Test(string testMessage)
    {
        return Task.FromResult($"You said {testMessage}");
    }
}