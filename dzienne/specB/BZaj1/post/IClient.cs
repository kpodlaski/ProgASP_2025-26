namespace post;

public interface IClient
{
    public void Task(
        IPostOfficer office);
    int Id { get; }
}