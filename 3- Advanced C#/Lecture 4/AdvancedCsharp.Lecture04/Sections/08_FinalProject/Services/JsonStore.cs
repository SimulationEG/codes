using System.Text.Json;

namespace AdvancedCsharp.Lecture04.Sections._08_FinalProject.Services;

/// <summary>
/// Generic async JSON store for any <typeparamref name="T"/>.
/// Reads and writes through a <see cref="FileStream"/> (not ReadAllText / WriteAllText).
/// </summary>
public sealed class JsonStore<T>
{
    static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    readonly string _filePath;
    readonly Func<T, object>? _keyOf;

    /// <param name="filePath">JSON array file (e.g. Data/employees.json).</param>
    /// <param name="keyOf">Optional unique key, e.g. <c>e =&gt; e.Id</c>.</param>
    public JsonStore(string filePath, Func<T, object>? keyOf = null)
    {
        _filePath = filePath;
        _keyOf = keyOf;

        string? folder = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(folder))
            Directory.CreateDirectory(folder);
    }

    // ── load / save (streams) ───────────────────────────────────────────

    public async Task EnsureCreatedAsync(CancellationToken ct = default)
    {
        if (File.Exists(_filePath))
            return;

        await SaveAsync(new List<T>(), ct);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken ct = default)
    {
        if (!File.Exists(_filePath))
            return new List<T>();

        try
        {
            await using FileStream stream = File.OpenRead(_filePath);

            if (stream.Length == 0)
                return new List<T>();

            List<T>? items = await JsonSerializer.DeserializeAsync<List<T>>(stream, Options, ct);
            return items ?? new List<T>();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"{Path.GetFileName(_filePath)} is not valid JSON: {ex.Message}", ex);
        }
    }

    public async Task SaveAsync(List<T> items, CancellationToken ct = default)
    {
        string tempPath = _filePath + ".tmp";

        await using (FileStream stream = File.Create(tempPath))
        {
            await JsonSerializer.SerializeAsync(stream, items, Options, ct);
        }

        File.Move(tempPath, _filePath, overwrite: true);
    }

    // ── queries ─────────────────────────────────────────────────────────

    public async Task<T?> FindAsync(Func<T, bool> match, CancellationToken ct = default)
    {
        List<T> items = await GetAllAsync(ct);
        return items.FirstOrDefault(match);
    }

    public async Task<List<T>> FindAllAsync(Func<T, bool> match, CancellationToken ct = default)
    {
        List<T> items = await GetAllAsync(ct);
        return items.Where(match).ToList();
    }

    // ── commands ────────────────────────────────────────────────────────

    public async Task AddAsync(T item, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(item);

        List<T> items = await GetAllAsync(ct);

        if (_keyOf is not null)
        {
            object key = _keyOf(item);
            if (items.Any(x => Equals(_keyOf(x), key)))
                throw new InvalidOperationException($"An item with key '{key}' already exists.");
        }

        items.Add(item);
        await SaveAsync(items, ct);
    }

    public async Task<bool> UpdateAsync(Func<T, bool> match, T item, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(item);

        List<T> items = await GetAllAsync(ct);
        int index = items.FindIndex(x => match(x));
        if (index < 0)
            return false;

        items[index] = item;
        await SaveAsync(items, ct);
        return true;
    }

    public async Task<bool> DeleteAsync(Func<T, bool> match, CancellationToken ct = default)
    {
        List<T> items = await GetAllAsync(ct);
        if (items.RemoveAll(x => match(x)) == 0)
            return false;

        await SaveAsync(items, ct);
        return true;
    }
}
