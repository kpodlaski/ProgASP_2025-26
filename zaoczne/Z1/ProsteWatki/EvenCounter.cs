namespace ProsteWatki;

public class EvenCounter
{
    private int value;
    
    public void Increase()
    {
        lock (this)
        {
            value++;
            value++;
        }
    }

    public int ActualValue()
    {
        lock (this)
        {
            return value;
        }
    }
    
    public void count()
    {
        while (true)
            Increase();
    }
}