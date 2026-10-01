// ============================================================
// Lecture 02 — (10) Indexers
// Library[int] · Library[isbn] like an array / dictionary
// Run:  dotnet run --project 10-Indexers
// ============================================================

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // (1) Without indexer — verbose method names
        Console.WriteLine("=== (1) Before: GetBookAtPosition ===");
        var plain = new LibraryWithoutIndexer();
        plain.Add(new Book("978-014", "The Odyssey"));
        plain.Add(new Book("978-013", "Clean Code"));
        Console.WriteLine(plain.GetBookAtPosition(0).Title);

        Book? byIsbn = plain.FindBookByIsbn("978-013");
        if (byIsbn != null)
            Console.WriteLine(byIsbn.Title);
        else
            Console.WriteLine("ISBN not found (plain)");

        // (2) With indexer — natural syntax
        Console.WriteLine();
        Console.WriteLine("=== (2) After: library[i] / library[isbn] ===");
        var library = new Library();
        library.Add(new Book("978-014", "The Odyssey"));
        library.Add(new Book("978-013", "Clean Code"));

        Book first = library[0];
        Book? found = library["978-013"];
        library[0] = new Book("978-020", "Refactoring");

        Console.WriteLine(first.Title);
        if (found != null)
            Console.WriteLine(found.Title);
        Console.WriteLine(library[0].Title);

        // (3) Validation — bad int index throws; missing ISBN returns null
        Console.WriteLine();
        Console.WriteLine("=== (3) Validation ===");
        try { _ = library[-1]; }
        catch (Exception ex) { Console.WriteLine($"index=-1: {ex.Message}"); }

        try { _ = library[99]; }
        catch (Exception ex) { Console.WriteLine($"index=99: {ex.Message}"); }

        try { _ = library[""]; }
        catch (Exception ex) { Console.WriteLine($"isbn empty: {ex.Message}"); }

        Book? missing = library["no-such"];
        if (missing == null)
            Console.WriteLine("isbn missing: null (not found)");
        else
            Console.WriteLine(missing.Title);
    }
}

class Book
{
    public Book(string isbn, string title)
    {
        Isbn = isbn;
        Title = title;
    }

    public string Isbn { get; }
    public string Title { get; }
}

// (1) Verbose API
class LibraryWithoutIndexer
{
    private readonly List<Book> _books = new();
    public void Add(Book book) => _books.Add(book);
    public Book GetBookAtPosition(int index) => _books[index];

    public Book? FindBookByIsbn(string isbn)
    {
        for (int i = 0; i < _books.Count; i++)
        {
            if (_books[i].Isbn == isbn)
                return _books[i];
        }

        return null;
    }
}

// (2) Indexer API
class Library
{
    private readonly List<Book> _books = new();

    public void Add(Book book) => _books.Add(book);

    // (3) int indexer — position (validate range)
    public Book this[int index]
    {
        get
        {
            if (index < 0 || index >= _books.Count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {_books.Count - 1}.");
            return _books[index];
        }
        set
        {
            if (index < 0 || index >= _books.Count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {_books.Count - 1}.");
            _books[index] = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    // (4) string indexer — ISBN (empty throws; missing returns null)
    public Book? this[string isbn]
    {
        get
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN is required.", nameof(isbn));

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Isbn == isbn)
                    return _books[i];
            }

            return null;
        }
    }
}
