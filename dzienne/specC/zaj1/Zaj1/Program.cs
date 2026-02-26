using System.Runtime.InteropServices;

namespace Zaj1;

class Program
{
    
    static void Main2(string[] args)
    {
        Counter c = new Counter();
        for (int a = 0; a < 100; a++)
        {
            c.StartCounter();
        }
        Thread.Sleep(3000);
        Console.WriteLine(c.Value);
    }

    static void Main(string[] args)
    {
        EvenCounter c = new EvenCounter();
        c.StartCounter();
        ParityCheck ch = new ParityCheck(c);
        ch.StartChecking();
    }
}