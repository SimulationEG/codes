// Lecture 03 — UML relationships in C#
Console.WriteLine("========== 1) Association — Teacher / Student ==========");
var s1 = new Student { Name = "Ali" };
var s2 = new Student { Name = "Sara" };
var teacher = new Teacher { Name = "Dr. Nora" };
teacher.Teach(s1);
teacher.Teach(s2);
Console.WriteLine($"{teacher.Name} teaches {teacher.Students.Count} students");
// Students still exist if we drop teacher reference

Console.WriteLine("\n========== 2) Aggregation — Department / Employee ==========");
var empA = new Employee { Name = "Omar" };
var empB = new Employee { Name = "Mona" };
var dept = new Department("Cardiology", [empA, empB]);
Console.WriteLine($"{dept.Title} staff={dept.Staff.Count}");
dept = null!; // department gone — employees still alive via empA/empB
Console.WriteLine($"Employees still exist: {empA.Name}, {empB.Name}");

Console.WriteLine("\n========== 3) Composition — House owns Rooms ==========");
var house = new House();
Console.WriteLine($"House rooms: {string.Join(", ", house.RoomNames)}");
house = null!; // rooms were only reachable through house → eligible for GC

Console.WriteLine("\n========== 4) Dependency — method-only use ==========");
new ReportService().Generate("report.pdf");

Console.WriteLine("\n========== 5) Inheritance is-a — Animal / Dog ==========");
var dog = new Dog { Name = "Rex" };
dog.Eat();
dog.Bark();

class Student { public string Name { get; set; } = ""; }

class Teacher
{
    public string Name { get; set; } = "";
    public List<Student> Students { get; } = new();
    public void Teach(Student s) => Students.Add(s);
}

class Employee { public string Name { get; set; } = ""; }

class Department
{
    public string Title { get; }
    public List<Employee> Staff { get; }
    public Department(string title, List<Employee> staff)
    {
        Title = title;
        Staff = staff; // weak ownership — staff created outside
    }
}

class Room
{
    public string Name { get; }
    public Room(string name) => Name = name;
}

class House
{
    private readonly List<Room> _rooms = new();
    public House()
    {
        _rooms.Add(new Room("Kitchen"));
        _rooms.Add(new Room("Bedroom"));
    }
    public IEnumerable<string> RoomNames => _rooms.Select(r => r.Name);
}

class PdfWriter
{
    public void Write(string path, string content)
        => Console.WriteLine($"PDF -> {path}: {content}");
}

class ReportService
{
    public void Generate(string path)
    {
        var writer = new PdfWriter(); // dependency — local only
        writer.Write(path, "Monthly report");
    }
}

class Animal
{
    public string Name { get; set; } = "";
    public void Eat() => Console.WriteLine($"{Name} eating...");
}

class Dog : Animal
{
    public void Bark() => Console.WriteLine($"{Name}: Woof");
}
