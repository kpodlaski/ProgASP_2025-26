namespace Zaj1.postoffice;

public interface IPostOffice
{
    public void AddNewClient(IClient c);
    void ServeClient(IClient c);
    public void StartWork();
}

