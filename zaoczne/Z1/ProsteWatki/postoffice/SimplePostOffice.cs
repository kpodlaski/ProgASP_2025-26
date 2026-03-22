namespace ProsteWatki.postoffice;

public class SimplePostOffice : IPostOffice
{
    private IPostOfficer officer;
    public void AddNewClient(IClient c)
    {
        Console.WriteLine("Klient {0} wszedł na pocztę",c.Id);
        ServeClient(c);
    }

    public void ServeClient(IClient c)
    {
        officer.ServeClient(c);
    }

    public void StartWork()
    {
        officer = new Officer(1);
        Console.WriteLine("Poczta gotowa do pracy");
    }
}