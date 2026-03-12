namespace post;

public interface IPostOfficer
{
    void ServeClient(IClient c);
    bool IsAvailable();
}