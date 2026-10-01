namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>Deck 03 — Queue FIFO + Stack LIFO.</summary>
public static class Ex09_QueueStack
{
    public static void Run()
    {
        var jobs = new Queue<string>();
        jobs.Enqueue("A");
        jobs.Enqueue("B");
        Console.WriteLine($"Queue Peek={jobs.Peek()}, Dequeue={jobs.Dequeue()}");

        var stack = new Stack<string>();
        stack.Push("A");
        stack.Push("B");
        Console.WriteLine($"Stack Peek={stack.Peek()}, Pop={stack.Pop()}");
    }
}
