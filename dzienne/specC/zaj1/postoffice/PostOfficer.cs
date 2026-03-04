namespace Zaj1.postoffice;

public class PostOfficer : IPostOfficer
{
    private Mutex mutex = new Mutex();

    public void ServeClient(IClient c)
    {
        mutex.WaitOne();
        Console.WriteLine("Serving client {0}", c.Id);
        c.Task(this);
        mutex.ReleaseMutex();
    }
}