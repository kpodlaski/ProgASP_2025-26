using System.Data.SqlTypes;

namespace Zaj1.postoffice;

public class PostOfficer : IPostOfficer
{
    private Mutex mutex = new Mutex();
    private volatile bool isAvailabe = true;
    public int ID { get; private set; }
    private static int last_id = 0;

    public PostOfficer()
    {
        ID = last_id++;
    }

    public void ServeClient(IClient c)
    {
        mutex.WaitOne();
        if (!IsAvailable())
        {
            throw new Exception(String.Format("PostOfficer {0} is not available", ID));
        }
        isAvailabe = false;
        Console.WriteLine("Officer {1} is serving client {0}", c.Id, ID);
        c.Task(this);
        isAvailabe = true;
        mutex.ReleaseMutex();
    }

    public bool IsAvailable()
    {
        //There is a risk that is available gives true, but officer gets busy in the meantime
        return isAvailabe;
    }
}