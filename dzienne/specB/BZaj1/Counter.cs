using System.Net.Http.Headers;

namespace Zaj1;

public class Counter
{
    private int value;
    public void Increase() {
        value++;
    }
    public int Value() {
        return value;
    }
    
    public static void MainCounter(string[] args)
    {
        Counter c = new Counter();
        ThreadTask task = new ThreadTask(c);
        for (int i = 0; i < 100; i++)
        {
            Thread t  = new 
                Thread(new ThreadStart(task.Task));
            t.Start();
        }
        Thread.Sleep(3000);
        Console.WriteLine(c.Value());
    }
}