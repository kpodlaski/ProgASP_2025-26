using Zaj1.stud;

namespace Zaj1;

class Program
{
    static void Main(string[] args)
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
}