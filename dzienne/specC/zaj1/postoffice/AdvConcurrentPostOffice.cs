namespace Zaj1.postoffice;

public class AdvConcurrentPostOffice : IPostOffice
{
    private Queue<IPostOfficer> availableOfficers = new Queue<IPostOfficer>();
    private int size;
    private Semaphore semaphore;
    
    public AdvConcurrentPostOffice(int numberOfOfficers)
    {
        size=numberOfOfficers;
        semaphore = new Semaphore(0,size);
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
        lock (this)
        {
            officer =  availableOfficers.Dequeue();
        }
        if (officer != null)
        {
            officer.ServeClient(c);
            lock (this)
            {
                availableOfficers.Enqueue(officer);
            }
            semaphore.Release();
        }
        else
        {
            throw new Exception("ERROR, nie ma wolnego oficera wewnątrz semafora");
        }
    }

    public void StartWork()
    {
        for (int i = 0; i < size; i++)
        {
            IPostOfficer officer = new PostOfficer();
            availableOfficers.Enqueue(officer);
            
        }
        Console.WriteLine("Otwieramy pocztę, mamy {0} okienka", size);
        semaphore.Release(size);
    }
    
    public static void  Program()
    {
        AdvConcurrentPostOffice postOffice = new AdvConcurrentPostOffice(3);
        postOffice.StartWork();
        for (int i = 0; i < 30; i++)
        {
            IClient c = new Client(postOffice);
        }
        Console.WriteLine("Koniec metody Program");
    }
}