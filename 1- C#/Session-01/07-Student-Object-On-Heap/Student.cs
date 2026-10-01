// Reference type used in the heap demo.
public class Student
{
    public string Name = "";
    public int Age;
    public double GPA;

    public void Print()
    {
        Console.WriteLine(Name + " (" + Age + ") GPA=" + GPA);
    }
}
