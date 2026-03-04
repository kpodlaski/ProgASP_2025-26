namespace Zaj1;

public class EvenCounter
{
    private volatile int value;
    private Mutex mutex = new Mutex();

    public int GetValue()
    {
        //lock (this)
        //{
        mutex.WaitOne();
            return value;
        //}
        mutex.ReleaseMutex();
    }

    public void Increment()
    {
        // lock (this)
        // {
        mutex.WaitOne();
            value++;
            value++;
        //}
        mutex.ReleaseMutex();
    }

    private void count() {
        while (true) {
            Increment();
        }
    }
    
    public void StartCounter() {
        Thread t = new(new ThreadStart(count));
        t.Start();
    }
}