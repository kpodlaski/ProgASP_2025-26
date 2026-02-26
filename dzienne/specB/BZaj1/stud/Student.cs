namespace Zaj1.stud;

public class Student : Person
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
}