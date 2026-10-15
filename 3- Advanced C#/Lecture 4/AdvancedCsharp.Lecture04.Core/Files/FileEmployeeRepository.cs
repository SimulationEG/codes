using System.Text.Json;

namespace AdvancedCsharp.Lecture04.Core.Files;

/// <summary>Deck slides 101–102 — async file store for lifecycle + async Task tests.</summary>
public sealed class FileEmployeeRepository
{
    static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    readonly string _path;

    public FileEmployeeRepository(string path)
    {
        _path = path;
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
        if (!File.Exists(_path))
            File.WriteAllText(_path, "[]");
    }

    public async Task<bool> AddAsync(Employee employee)
    {
        var all = await LoadAsync();
        if (all.Any(e => e.Id == employee.Id))
            return false;

        all.Add(employee);
        await SaveAsync(all);
        return true;
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        var all = await LoadAsync();
        return all.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var all = await LoadAsync();
        if (all.RemoveAll(e => e.Id == id) == 0)
            return false;

        await SaveAsync(all);
        return true;
    }

    async Task<List<Employee>> LoadAsync()
    {
        string json = await File.ReadAllTextAsync(_path);
        return JsonSerializer.Deserialize<List<Employee>>(json, Options) ?? [];
    }

    async Task SaveAsync(List<Employee> employees)
    {
        await File.WriteAllTextAsync(_path, JsonSerializer.Serialize(employees, Options));
    }
}
