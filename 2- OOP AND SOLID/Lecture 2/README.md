# OOP Lecture 02 — Cleaner Objects · Language Tools

Simulation Academy · .NET Diploma · OOP & SOLID module

Companion demos for **`OOP_Lecture_02.pptx`**
(`OOP_Lecture_02_COMPLETE_RECORD_COPY_FINAL.pptx`).

## Deck

- `OOP_Lecture_02.pptx`

## Projects (match the PowerPoint)

| # | Project | PowerPoint section |
|---|---------|-------------------|
| 01 | Properties | Full · auto · init · required · private set · computed · `field` |
| **02** | **Order-Practice** | **After properties:** Customer · Product · OrderItem · Order (readonly + read-only props) |
| 04 | Builder | `BeforeRefactoring` large ctor → `AfterRefactoring` fluent builder |
| 05 | Structs | Value copy · `readonly struct` · Money vs class |
| 06 | Object-Class | `ToString` · `GetType` · `ReferenceEquals` |
| 07 | Equals-GetHashCode | Defaults · string · domain Equals · `HashCode.Combine` |
| 08 | IComparable | `BeforeRefactoring` Sort fails → `AfterRefactoring` CompareTo |
| 09 | Records | Value equality · positional · `with` · shallow-copy note |
| 10 | Indexers | `library[i]` / `library[isbn]` |
| 11 | DRY-KISS-YAGNI | `BeforeRefactoring` smells → `AfterRefactoring` fixes |

## Run

```bash
dotnet run --project 01-Properties
dotnet run --project 02-Order-Practice
dotnet run --project 04-Builder
dotnet run --project 08-IComparable
dotnet run --project 11-DRY-KISS-YAGNI
```

Or open `Lecture02.slnx`.

## Teaching notes

1. Properties first, then **Order-Practice** so students apply read-only / `readonly` immediately.
2. For Builder, IComparable, DRY/KISS/YAGNI: open **`BeforeRefactoring`** then **`AfterRefactoring`** with students.
3. Comments are numbered `(1)`, `(2)`, … so you can pause on each step.
4. Do **not** use a language feature before its demo (e.g. no `override ToString` before **Object-Class**).

## Style

Match Lecture 01: short steps, hospital / academy domain where it helps, no features ahead of the deck.

