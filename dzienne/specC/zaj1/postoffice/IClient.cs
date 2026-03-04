namespace Zaj1.postoffice;

public interface IClient
{
    public void Task(IPostOfficer office);
    int Id { get; }
}