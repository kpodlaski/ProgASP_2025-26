namespace ProsteWatki.postoffice;

public class ConcurentPostOffice : IPostOffice
{
    private List<IPostOfficer> officers = new List<IPostOfficer>();
    private bool[] officersAviability;
    private int size;
    private Semaphore semaphore;
    
    public ConcurentPostOffice(int numberOfOfficers)
    {
        size=numberOfOfficers;
        officersAviability = new bool[size];
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
        int officerId = -1;
        lock (this)
        {
            for (int i=0; i<size; i++)
            {
                if (officersAviability[i])
                {
                    officersAviability[i] = false;
                    officerId = i;
                    break;
                }
            }
        }
        if (officerId >=0)
        {
            officers[officerId].ServeClient(c);
            lock (this)
            {
                officersAviability[officerId] = true;
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
            IPostOfficer officer = new Officer(i+1);
            officers.Add(officer);
            officersAviability[i] = true;
        }
        Console.WriteLine("Otwieramy pocztę, mamy {0} okienka", size);
        Console.WriteLine(officers.Count);
        semaphore.Release(size);
    }
    
    public static void  Program()
    {
        ConcurentPostOffice postOffice = new ConcurentPostOffice(3);
        postOffice.StartWork();
        for (int i = 0; i < 30; i++)
        {
            IClient c = new Client(postOffice, i+1);
        }
        Console.WriteLine("Koniec metody Program");
    }
}