namespace Zaj1;

public class EvenCounter
{
    private volatile int value;

    public int GetValue()
    {
        lock (this)
        {
            return value;
        }
    }

    public void Increment()
    {
        lock (this)
        {
            value++;
            value++;
        }
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