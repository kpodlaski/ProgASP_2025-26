namespace Zaj1;

public class Person
{
    public String Name;
    public String Surname;
    public long Pesel;

    public Person(String Name, String surname, long pesel)
    {
        this.Name = Name;
        Surname = surname;
    }

    public override string ToString()
    {
        return Name + " "+Surname;
    }

    public override bool Equals(object? obj)
    {
        Person p = (Person) obj ;
        return p.Pesel == this.Pesel;
        
    }
}