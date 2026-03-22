namespace Zaj1;

public class Person : IComparable<Person>
{
    public String Name;
    public String Surname;
    public long Pesel;

    public Person(String Name, String surname, long pesel)
    {
        this.Name = Name;
        Surname = surname;
        this.Pesel = pesel;
    }

    public override string ToString()
    {
        return Name + " "+Surname;
    }

    

    public int CompareTo(Person? other)
    {
        if (other == null)
            return 0;
        //return this.Pesel.CompareTo(other.Pesel);
        return (int)(this.Pesel/1000 - other.Pesel/1000);
    }

    public override bool Equals(object? obj)
    {
        Person p = (Person) obj ;
        return p.Pesel == this.Pesel;
        
    }
    
}

class PersonNameComaprer: IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        return x.Name.CompareTo(y.Name);
    }
}











