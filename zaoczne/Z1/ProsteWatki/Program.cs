using System.Net.Http.Headers;
using ProsteWatki.postoffice;

namespace ProsteWatki;

class Program
{
    
    
    static void Main1(string[] args)
    {
        Counter counter = new Counter();
        for (int i = 0; i < 1000; i++)
        {
            Thread t = new Thread(new ThreadStart(counter.user));
            t.Start();
        }
        Thread.Sleep(3000);
        Console.WriteLine(counter.ActualValue());
    }
    static void Main2(string[] args)
    {
        EvenCounter counter = new EvenCounter();
        CounterObserver obs = new CounterObserver(counter);
        Thread t = new Thread(new ThreadStart(counter.count));
        t.Start();

        t = new Thread(
            new ThreadStart(obs.check));
        t.Start();

    }

    static void Main3(string[] args)
    {
        IPostOffice post = new SimplePostOffice();
        post.StartWork();
        for (int i = 0; i < 20; i++)
        {
            Client c = new Client(post, i);
        }
        
        
    }

    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread t = new Thread(
                ()=>{Console.WriteLine(i);});
            t.Start();
        }
    }
}