namespace Zaj1.stud;

public class Student : Person, ISpeaker
{
    private int year;
    private int semester;
    public Student(string name, string surname, long pesel, int y, int sem) : base(name, surname, pesel)
    {
        this.year = y;
        this.semester = sem;
    }

    public override string ToString()
    {
        return base.ToString() + " sem:" + this.semester;
    }

    public string[] getLanguages()
    {
        return new[] { "polish" };
    }
    
    public override int GetHashCode()
    {
        return this.Pesel.GetHashCode();
    }
    
    public override bool Equals(object? obj)
    {
        Person p = (Person) obj ;
        return p.Pesel == this.Pesel;
        
    }
}