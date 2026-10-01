namespace AdvancedCsharp.Lecture02.Sections._11_Reflection;

/// <summary>
/// Deck: what a source generator emits (GeneratedMapper.g.cs).
/// In the full demo this file is produced at compile time by MapperGenerator;
/// here we keep it as ordinary code so the lab stays a single runnable project.
/// </summary>
public static class Ex04_GeneratedMapperStandIn
{
    public static void Run()
    {
        Console.WriteLine("Reflection  → runtime → inspect code (slower, late errors).");
        Console.WriteLine("Source Gen  → compile time → generate C# (fast, compiler-checked).");
        Console.WriteLine();

        var user = new Ex03_MappingProblem.User
        {
            Id = 1,
            Name = "Ahmed",
            Email = "ahmed@test.com"
        };

        // As if: var dto = GeneratedMapper.Map(user);
        var dto = GeneratedMapper.Map(user);
        Console.WriteLine(dto.Name); // Ahmed
    }
}

/// <summary>Stand-in for GeneratedMapper.g.cs from the deck.</summary>
static class GeneratedMapper
{
    public static Ex03_MappingProblem.UserDto Map(Ex03_MappingProblem.User user) => new()
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
    };
}
