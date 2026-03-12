namespace ProsteWatki.postoffice;

public interface IPostOfficer
{
    void ServeClient(IClient c);
    bool IsAvailable();
}