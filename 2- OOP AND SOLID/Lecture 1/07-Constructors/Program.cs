// ============================================================
// Lecture 01 — (7) Constructors
// Default · Parameterized · Overload / this() chaining · Private factory
// CLR zero-inits fields BEFORE any constructor runs.
// ============================================================

using System;

class Patient
{
    private string name;
    private int age;
    public static int Created;

    static Patient()
    {
        Created = 0;
        Console.WriteLine("[static ctor] Patient type initialized once");
    }

    // Default → chains to parameterized
    public Patient() : this("Unknown")
    {
    }

    public Patient(string name) : this(name, 0)
    {
    }

    // Real setup path
    public Patient(string name, int age)
    {
        this.name = name;
        this.age = age;
        Created++;
    }

    // Private ctor — only factory / same class can call
    private Patient(string name, int age, bool fromFactory)
    {
        this.name = name;
        this.age = age;
        Created++;
    }

    public static Patient Create(string name)
    {
        return new Patient(name, 0, true);
    }

    public string GetName() { return name; }
    public int GetAge() { return age; }

    public void Print()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
}

class Rectangle
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public Rectangle(int side) : this(side, side)
    {
    }

    public Rectangle() : this(0, 0)
    {
    }

    public void Print()
    {
        Console.WriteLine($"Rectangle {width} x {height}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Default / overload / chaining ===");
        Patient p0 = new Patient();
        Patient p1 = new Patient("Ali");
        Patient p2 = new Patient("Sara", 30);

        p0.Print();
        p1.Print();
        p2.Print();
        Console.WriteLine($"Patients created: {Patient.Created}");

        Console.WriteLine("\n=== Private ctor + factory ===");
        Patient p3 = Patient.Create("Omar");
        p3.Print();

        Console.WriteLine("\n=== Rectangle chaining with this() ===");
        Rectangle r1 = new Rectangle();
        Rectangle r2 = new Rectangle(5);
        Rectangle r3 = new Rectangle(4, 6);
        r1.Print();
        r2.Print();
        r3.Print();
    }
}
