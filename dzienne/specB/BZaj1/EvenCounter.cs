namespace Zaj1;

public class EvenCounter
{
    private int value;
    private Mutex mutex = new Mutex();

    public void Increase()
    {
        //lock (this) {
        mutex.WaitOne();
        value++;
        value++;
        mutex.ReleaseMutex();
        //}
    }
    public int Value() {
        //lock (this) {
        mutex.WaitOne(); 
        int v= value;
        mutex.ReleaseMutex();
        return v;
        //}
    }

    public void Count()
    {
        while (true)
        {
            Increase();
        }
    }
    
    
}