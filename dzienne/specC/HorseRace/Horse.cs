namespace HorseRace;

public class Horse : IComparable<Horse>
{
    Barrier startBarrier, endBarrier;
    private readonly int distance;
    public double speed = .01;
    public int ID;
    public long FinalTime = -1;
    Random rand = new Random();
    public bool Injury  = false;
    public Horse(int id, Barrier startBarrier, Barrier endBarrier, int distance)
    {
        this.ID = id;
        this.startBarrier = startBarrier;
        this.endBarrier = endBarrier;
        this.distance = distance;
        
        this.speed += (double) rand.NextDouble();
    }
    public void Run()
    {
        Console.WriteLine("Koń {0} jest na starcie", ID);
        double x = 0;
        int t = 0;
        startBarrier.SignalAndWait();
        while (x < distance)
        {
            t += 1;
            x += speed;
            double r = rand.NextDouble();
            if (r > .9999)
            {
                Injury = true;
                FinalTime = long.MaxValue;
                endBarrier.SignalAndWait();//endBarrier.RemoveParticipant();
                break; 
            }
        }
        if (!Injury)
        {
            FinalTime = DateTime.Now.Ticks; // / TimeSpan.TicksPerMillisecond;
            Console.WriteLine("Koń {0} na mecie", ID);
            endBarrier.SignalAndWait();
        }
    }
    
    public void GetReady()
    {
        Thread t = new Thread(new ThreadStart(this.Run));
        t.Start();
    }

    public int CompareTo(Horse? other)
    {
        return this.FinalTime.CompareTo(other.FinalTime);
    }
}