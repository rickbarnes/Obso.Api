namespace IServices;

public interface ITestService
{
    Task<string> Test(string testMessage);
}