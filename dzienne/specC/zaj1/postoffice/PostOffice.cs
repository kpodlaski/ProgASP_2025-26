namespace Zaj1.postoffice;

public class PostOffice : IPostOffice
{
    private int numberOfOfficers;
    private List<IPostOfficer> officers = new List<IPostOfficer>();
    private Semaphore semaphore; 
    public PostOffice(int numberOfOfficers)
    {
        this.numberOfOfficers = numberOfOfficers;
        semaphore = new Semaphore(0, numberOfOfficers);
        
    }

    public void AddNewClient(IClient c)
    {
        Console.WriteLine("Klient {0} wszedł na pocztę", c.Id);
        this.ServeClient(c);
    }

    public void ServeClient(IClient c)
    {
        semaphore.WaitOne();
        IPostOfficer officer = null; 
        foreach (IPostOfficer o in officers)
        {
            if (o.IsAvailable())
            {
                officer = o;
                break;
            }
        }
        officer.ServeClient(c);
        semaphore.Release();
    }

    public void StartWork()
    {
        for (int i = 0; i < numberOfOfficers; i++)
        {
            officers.Add(new PostOfficer());    
        }
        semaphore.Release(numberOfOfficers);
    }
    
    public static void  Program()
    {
        PostOffice postOffice = new PostOffice(3);
        postOffice.StartWork();
        for (int i = 0; i < 30; i++)
        {
            IClient c = new Client(postOffice);
        }
        Console.WriteLine("Koniec metody Program");
    }
}