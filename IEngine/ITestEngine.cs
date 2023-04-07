namespace Engine;

public interface ITestEngine
{
    Task<string> Test(string testMessage);
}