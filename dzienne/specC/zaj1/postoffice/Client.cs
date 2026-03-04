namespace Zaj1.postoffice;

public class Client : IClient
{
    public int Id {  get; private set; }
    private static volatile int lastId = 0;
    private IPostOffice postOffice;
    
    public Client(IPostOffice postOffice)
    {
        Id = lastId++;
        this.postOffice = postOffice;
        Thread t = new Thread(new ThreadStart(this.Visiting));
        t.Start();
    }
    public void Task(IPostOfficer office)
    {
        Console.WriteLine(String.Format("K{0} : Jestem przy okienku ",Id));
        Random rand = new Random();
        Thread.Sleep(rand.Next(200)+10);
        Console.WriteLine(String.Format("K{0} : Odchodzę od okienka ",Id));
    }

    private void Visiting()
    {
        this.postOffice.AddNewClient(this);
    }
}