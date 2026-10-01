namespace AdvancedCsharp.Lecture02.Sections._11_Reflection;

/// <summary>Deck: mapping problem — repetitive Map by hand.</summary>
public static class Ex03_MappingProblem
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public static void Run()
    {
        var user = new User { Id = 1, Name = "Ahmed", Email = "ahmed@test.com" };
        var dto = Map(user);
        Console.WriteLine($"{dto.Id} {dto.Name} {dto.Email}");
        Console.WriteLine("(Same Map code repeated by hand for Product, Order, Customer, Invoice...)");
    }

    static UserDto Map(User user) => new()
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
    };
}
