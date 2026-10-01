namespace Abstraction.Examples._03_AbstractShape;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Abstract Shape.Area ==========");
        Shape[] shapes = [new Circle(3), new Rectangle(4, 5)];
        foreach (var s in shapes)
            Console.WriteLine($"{s.GetType().Name} area={s.Area():F2}");
    }
}

abstract class Shape
{
    public abstract double Area();
}

class Circle : Shape
{
    public double Radius { get; }
    public Circle(double r) => Radius = r;
    public override double Area() => Math.PI * Radius * Radius;
}

class Rectangle : Shape
{
    public double W { get; }
    public double H { get; }
    public Rectangle(double w, double h) { W = w; H = h; }
    public override double Area() => W * H;
}
