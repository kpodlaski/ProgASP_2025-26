namespace Zaj1;

public class ParityCheck
{
    private EvenCounter counter;

    public ParityCheck(EvenCounter c)
    {
        this.counter = c;
    }

    public void StartChecking()
    {
        while (true)
        {
            int v;
            v = counter.GetValue(); 
              
            if (v % 2 != 0)
            {
                Console.WriteLine(
                     ("Errror "+v));
                Console.WriteLine(
                    counter.GetValue());
                Environment.Exit(11);
            }
        }
    }
}