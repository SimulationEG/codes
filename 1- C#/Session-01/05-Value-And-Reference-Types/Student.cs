// Reference type: variable holds an address to the heap object.
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
