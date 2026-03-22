namespace Zaj1;

public class ThreadTask
{
    private Counter counter;
    public ThreadTask(Counter counter)
    {
        this.counter = counter;
    }

    public void Task()
    {
        for (int i = 0; i < 1000; i++)

            lock (this)
            {
                counter.Increase();
            }
    }
}