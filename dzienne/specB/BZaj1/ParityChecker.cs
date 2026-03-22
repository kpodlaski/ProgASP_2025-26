namespace Zaj1;

public class ParityChecker
{
    private EvenCounter counter;
    public ParityChecker(EvenCounter counter)
    {
        this.counter = counter;
    }

    public void Check()
    {
        while (true)
        {
            int v=  counter.Value();
            
            if (v % 2 != 0)
            {
                Console.WriteLine(v);
                Console.WriteLine(counter.Value());
                throw new Exception("Parity Error");
            }
        }
    }
    public static void Main(string[] a)
    {
        EvenCounter counter = new EvenCounter();
        ParityChecker checker = new ParityChecker(counter);
        Thread t = new  Thread(new ThreadStart(counter.Count));
        t.Start();
        t = new  Thread(new ThreadStart(checker.Check));
        t.Start();
        
    }
}