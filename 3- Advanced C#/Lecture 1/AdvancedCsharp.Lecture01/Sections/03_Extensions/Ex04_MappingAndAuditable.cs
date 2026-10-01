namespace AdvancedCsharp.Lecture01.Sections._03_Extensions;

/// <summary>Deck 01 — mapping ToDto + extend IAuditable.</summary>
public static class Ex04_MappingAndAuditable
{
    public static void Run()
    {
        var user = new User { Id = 1, Name = "Belal", Email = "b@x.com" };
        UserDto dto = user.ToDto();
        Console.WriteLine($"DTO: {dto.Id}, {dto.Name}");

        var order = new OrderAuditable
        {
            CreatedAt = new DateTime(2026, 1, 1),
            UpdatedAt = null
        };
        Console.WriteLine(order.GetLastModifiedAt());
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
}

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public static class UserMappingExtensions
{
    public static UserDto ToDto(this User user) => new() { Id = user.Id, Name = user.Name };
}

public interface IAuditable
{
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; }
}

public class OrderAuditable : IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public static class AuditableExtensions
{
    public static DateTime GetLastModifiedAt(this IAuditable entity) =>
        entity.UpdatedAt ?? entity.CreatedAt;
}
