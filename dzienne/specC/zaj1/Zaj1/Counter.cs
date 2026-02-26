namespace Zaj1;

public class Counter
{
    public long Value;

    public void Count()
    {
        for (long i = 0; i < 1000; i++)
        {
            lock (this)
            {
                Value++;
            }
        }
    }

    public void StartCounter()
    {
        Thread t = new Thread(new ThreadStart(Count));
        t.Start();
    }
    
}