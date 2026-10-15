using AdvancedCsharp.Lecture04.Core.Files;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._05_AsyncAndLifecycle;

/// <summary>
/// PPT: "Async Tests: async Task, Then await"
/// PPT: "A New Test Object for Every Test" (ctor + IDisposable)
/// </summary>
public class FileEmployeeRepositoryTests : IDisposable
{
    readonly string _folder =
        Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    readonly string _path;

    public FileEmployeeRepositoryTests() // before EACH test
    {
        Directory.CreateDirectory(_folder);
        _path = Path.Combine(_folder, "employees.json");
    }

    public void Dispose() // after EACH test
    {
        if (Directory.Exists(_folder))
            Directory.Delete(_folder, recursive: true);
    }

    [Fact]
    public async Task Add_ThenGetById_ReturnsIt()
    {
        var repo = new FileEmployeeRepository(_path);

        await repo.AddAsync(new Employee(1, "Mona", 15000));
        Employee? found = await repo.GetByIdAsync(1);

        found.ShouldNotBeNull();
        found!.Name.ShouldBe("Mona");
    }

    [Fact]
    public async Task Add_Duplicate_ReturnsFalse()
    {
        var repo = new FileEmployeeRepository(_path);
        await repo.AddAsync(new Employee(1, "Mona", 15000));

        bool added = await repo.AddAsync(new Employee(1, "Mona", 15000));

        added.ShouldBeFalse();
    }

    [Fact]
    public async Task Delete_Missing_ReturnsFalse()
    {
        var repo = new FileEmployeeRepository(_path);

        bool deleted = await repo.DeleteAsync(99);

        deleted.ShouldBeFalse();
    }
}
