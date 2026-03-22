namespace ProsteWatki.postoffice;

public class Client : IClient
{
    public int Id { get; private set; }
    private IPostOffice post;

    public Client(IPostOffice post, int id)
    {
        this.Id = id;
        this.post = post;
        Thread t = new Thread(new ThreadStart(this.Visiting));
        t.Start();
    }
    
    public void Task(IPostOfficer officer)
    {
        Random rand = new Random();
        Console.WriteLine("Klient {0} podszedł do okienka",Id);
        Thread.Sleep(rand.Next(100)+10);
        Console.WriteLine("Klient {0} odchodzi od okienka",Id);
    }

    private void Visiting()
    {
        //this.post.AddNewClient(this);
        this.post.ServeClient(this);
    }
    
}