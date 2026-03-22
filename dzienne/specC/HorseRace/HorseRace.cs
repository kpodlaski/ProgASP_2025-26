namespace HorseRace;

public class HorseRace
{
    private List<Horse> horses = new List<Horse>();
    private Barrier startBarrier, endBarrier;
    private int distance;
    private long startTime;
    public HorseRace(int horseCount, int distance)
    {
        this.distance = distance;
        startBarrier = new Barrier(horseCount, startBarierMethod);
        endBarrier = new Barrier(horseCount, printResults);
        for (int i = 0; i < horseCount; i++)
        {
            Horse h = new Horse(i+1, startBarrier, endBarrier, distance);
            horses.Add(h);
        }
    }

    public void Wyscig()
    {
        foreach (Horse h in horses)
        {
            h.GetReady();
        }
        Console.WriteLine("Konie szykuja sie");
    }
    private void printResults(Barrier obj)
    {
        Console.WriteLine("Koniec wyścigu");
        horses.Sort();
        Console.WriteLine("============");
        Console.WriteLine("Wyniki:");
        for (int i = 0; i < horses.Count; i++)
        {
            if (!horses[i].Injury)
                Console.WriteLine("Miejsce {0} - Koń: {1} -- z czasem :{2}, v:{3} ", i, horses[i].ID, (int) (horses[i].FinalTime-startTime), horses[i].speed);
            else Console.WriteLine("Miejsce {0} - Koń: {1} -- {2}", i, horses[i].ID, "Kontuzja");
        }
        Console.WriteLine("============");
    }

    private void startBarierMethod(Barrier obj)
    {
        Console.WriteLine("Start wyścigu");
        startTime = DateTime.Now.Ticks;// / TimeSpan.TicksPerMillisecond;
        
    }
}