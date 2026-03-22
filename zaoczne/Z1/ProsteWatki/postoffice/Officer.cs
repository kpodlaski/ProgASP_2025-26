namespace ProsteWatki.postoffice;

public class Officer : IPostOfficer
{
    private int Id;
    private bool isAvailable = true;
    private Mutex mutex = new Mutex();

    public Officer(int id)
    {
        this.Id = id;
    }
    public void ServeClient(IClient c)
    {
        // Zakomentowana wersja z lock, uzyto analogicznej mutex
        // lock (this)
        // {
        mutex.WaitOne();
            isAvailable = false;
            Console.WriteLine("Okienko {0} obługuje klienta {1}",this.Id, c.Id);
            c.Task(this);
            isAvailable = true;
       mutex.ReleaseMutex();     
        // }
    }

    public bool IsAvailable()
    {
        return isAvailable;
    }
}