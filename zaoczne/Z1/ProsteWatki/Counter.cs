namespace ProsteWatki;

public class Counter
{
    private int value;
    
    public void Increase()
    {
        value++;
    }

    public int ActualValue()
    {
        lock (this)
        {
            return value;
        }
    }
    
    public void user()
    {
        for (int i = 0; i < 1000; i++)
        {
            Increase();
        }
    }
}