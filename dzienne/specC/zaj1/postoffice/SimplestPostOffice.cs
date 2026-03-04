namespace Zaj1.postoffice;

public class SimplestPostOffice: IPostOffice
{
    private IPostOfficer officer;
    public SimplestPostOffice()
    {
        officer = new PostOfficer();
    }
        
    public void AddNewClient(IClient c)
    {
        Console.WriteLine("Klient {0} wszedł na pocztę", c.Id);
        this.ServeClient(c);
    }

    public void ServeClient(IClient c)
    {
        officer.ServeClient(c);
    }

    public void StartWork()
    {
        Console.WriteLine("Otwieramy pocztę, mamy tylko jedno okienko");
    }

    public static void  Program()
    {
        SimplestPostOffice postOffice = new SimplestPostOffice();
        postOffice.StartWork();
        for (int i = 0; i < 30; i++)
        {
            IClient c = new Client(postOffice);
        }
        Console.WriteLine("Koniec metody Program");
    }
}