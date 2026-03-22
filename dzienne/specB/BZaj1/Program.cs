using Zaj1.stud;

namespace Zaj1;

class Program
{
    static void Main2(string[] args)
    {
        Person p = new Person("John", "Doe", 82011304352);
        Person p2 = p;
        Console.WriteLine(p);
        p = new Person("Jane", "Doe", 82011304352);
        Student s = new Student("Jane", "Doe", 82011304352, 3, 5);
        if (p == p2)
        {
            Console.WriteLine("Równość");
        }
        if (p.Equals(p2))
        {
            Console.WriteLine("Równość ale Equals");
        }
        if (p == s)
        {
            Console.WriteLine("Równość Person p i Student s");
        }
        if (p.Equals(s))
        {
            Console.WriteLine("Równość ale Equals");
        }
    }

    static void Main3(string[] args)
    {
        Person[] persons = new Person[10];
        persons[1]= new Person("Jóhn", "Doe", 82011304352);
        List<Person> personsList = new List<Person>();
        personsList.Add(persons[1]);
        personsList.Add(new Person("Jąne", "Doe", 95011304352));
        personsList.Add(new Student("Jimy", "Doe", 10031304352, 3, 5));
        Console.WriteLine(personsList.Count);
        //Console.WriteLine(personsList[2]);
        foreach (Person p in personsList)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine("================");
        personsList.Sort();
        personsList.Sort(new PersonNameComaprer());
        foreach (Person p in personsList)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine(personsList[2].CompareTo(personsList[0]));
        Console.WriteLine( ((Student) personsList[1]).getLanguages());
        
        Dictionary<Person, string> team = new Dictionary<Person, string>();
        team.Add(personsList[2], "A");
        team.Add(personsList[1], "A");
        team[personsList[0]] = "B";
        team[personsList[1]] = "C";
        Student s = new Student("Jimy", "Doe", 10031304352, 3, 5);
        Console.WriteLine(team[s]);
        //Przykład kiedy GetHeshCode nie zgadza się z Equals
        //Console.WriteLine(team[ new Person("Jąne", "Doe", 95011304352) ]);
        
        
        
        
    }
}