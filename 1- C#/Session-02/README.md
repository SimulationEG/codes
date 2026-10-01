# Session 02 — C# Basics Lecture 02

Companion demos for **C# Basics Lecture 02** (`CSharp_Basics_Lecture_02.pptx`).

Only topics from this lecture are included.

## Deck

- `CSharp_Basics_Lecture_02.pptx`

## Projects

| # | Project | Lecture topic |
|---|---------|----------------|
| 01 | Single-File-Apps | `.NET 10` single-file / `dotnet run hello.cs` |
| 02 | Mutable-Immutable | Mutable vs immutable · string quiz |
| 03 | String-Intern-Pool | Intern pool · `ReferenceEquals` |
| 04 | String-Methods | Validate · search · modify · split · compare · reverse |
| 05 | StringBuilder | Mutable buffer · `ToString` · tiny benchmark |
| 06 | String-Formatting | `$"..."` · `+` · `Concat` / `Join` · `Format` |
| 07 | Dates-And-Time | `DateTime` · `DateTimeOffset` · `DateOnly` / `TimeOnly` |
| 08 | Decisions | `if` · extract bool method · early exit · `switch` |
| 09 | Ternary | `?:` good vs bad |
| 10 | Loops | `for` · `while` · `do` · `foreach` · `break`/`continue` |
| 11 | Default-Values | Field defaults · value vs reference |

## Run

```bash
dotnet run --project 01-Single-File-Apps
dotnet run samples/hello.cs
dotnet run --project 08-Decisions
dotnet run --project 10-Loops
```

Or open `Session02.sln` in Visual Studio.

## Style notes

- Classic `class Program` + `static void Main()` in project demos
- `samples/hello.cs` is a true top-level single-file sample for `.NET 10`
- Decisions demo includes: **extract complex bool → method** and **early-exit guards**

