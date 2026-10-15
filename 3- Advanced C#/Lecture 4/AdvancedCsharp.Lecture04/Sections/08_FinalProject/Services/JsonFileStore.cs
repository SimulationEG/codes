using System.Text.Json;

namespace AdvancedCsharp.Lecture04.Sections._08_FinalProject.Services;

/// <summary>
/// Generic JSON file store — serialize / deserialize any <typeparamref name="T"/> list.
/// Same atomic save pattern as the deck's EmployeeService, but not tied to Employee.
/// </summary>
public sealed class JsonFileStore<T>
{
    static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    readonly string _filePath;
    readonly Func<T, object>? _keySelector;

    /// <param name="filePath">Path to the JSON array file.</param>
    /// <param name="keySelector">
    /// Optional unique key (e.g. <c>e =&gt; e.Id</c>).
    /// When set, <see cref="Add"/> refuses duplicates.
    /// </param>
    public JsonFileStore(string filePath, Func<T, object>? keySelector = null)
    {
        _filePath = filePath;
        _keySelector = keySelector;
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
        if (!File.Exists(_filePath))
            Save(new List<T>());
    }

    public List<T> GetAll()
    {
        try
        {
            string json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json, Options)
                   ?? new List<T>();
        }
        catch (FileNotFoundException)
        {
            return new List<T>();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"{Path.GetFileName(_filePath)} is not valid JSON: {ex.Message}", ex);
        }
    }

    public void Save(List<T> items)
    {
        string temp = _filePath + ".tmp";
        File.WriteAllText(temp, JsonSerializer.Serialize(items, Options));
        File.Move(temp, _filePath, overwrite: true);
    }

    public T? Find(Func<T, bool> predicate) =>
        GetAll().FirstOrDefault(predicate);

    public List<T> FindAll(Func<T, bool> predicate) =>
        GetAll().Where(predicate).ToList();

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        List<T> items = GetAll();

        if (_keySelector is not null)
        {
            object key = _keySelector(item);
            if (items.Any(existing => Equals(_keySelector(existing), key)))
                throw new InvalidOperationException(
                    $"An item with key '{key}' already exists.");
        }

        items.Add(item);
        Save(items);
    }

    public bool Update(Func<T, bool> match, T replacement)
    {
        ArgumentNullException.ThrowIfNull(replacement);
        List<T> items = GetAll();
        int index = items.FindIndex(x => match(x));
        if (index == -1)
            return false;

        items[index] = replacement;
        Save(items);
        return true;
    }

    public bool Delete(Func<T, bool> match)
    {
        List<T> items = GetAll();
        if (items.RemoveAll(x => match(x)) == 0)
            return false;

        Save(items);
        return true;
    }
}
