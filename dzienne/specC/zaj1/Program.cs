using System.Runtime.InteropServices;
using Zaj1.postoffice;

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

    static void Main3(string[] args)
    {
        EvenCounter c = new EvenCounter();
        c.StartCounter();
        ParityCheck ch = new ParityCheck(c);
        ch.StartChecking();
    }

    static void Main(string[] args)
    {
        //Simple Post Office
        //SimplestPostOffice.Program();
        //Multi officers Post Office
        PostOffice.Program();
    }
}