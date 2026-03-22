using System.ComponentModel.Design;

namespace ProsteWatki;

public class CounterObserver
{
    EvenCounter counter;
    public CounterObserver(EvenCounter counter)
    {
        this.counter = counter;
    }

    public void check()
    {
        while (true)
        {
            int v;
            v = counter.ActualValue();
            if (v % 2 != 0)
            {
                Console.WriteLine("ERRRORR");
                Console.WriteLine(v);
                Console.WriteLine(counter.ActualValue());
                throw new Exception("Exit");
            }
        }
    }
}