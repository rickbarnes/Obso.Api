namespace IRepository;

public interface ITestRepository
{
    Task<string> Test(string testMessage);
}