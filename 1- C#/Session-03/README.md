# Session 03 — C# Basics Lecture 03

Companion demos for **C# Basics Lecture 03** (`CSharp_Basics_Lecture_03.pptx`).

**Only topics from this lecture (GC section skipped):** Nullable · Errors · Exceptions · Enums · 1D Arrays · Methods.

## Deck

- `CSharp_Basics_Lecture_03.pptx`

## Projects

| # | Project | Lecture topic |
|---|---------|----------------|
| 01 | Nullable-Value-Types | `int?` · `HasValue` · `Value` · `??` / `??=` (no try/catch here) |
| 02 | Nullable-Reference-Types | `Employee` / `Department?` · `?` · `?.` · `??` · `!` |
| 03 | Error-Types | Syntax · Runtime · Logical · Warning (**identify only**) |
| 04 | Exception-Handling | try/catch · try/catch/finally · multiple catch · `catch when` (**no custom exceptions**) |
| 05 | Throw-Vs-ThrowEx | Main→Fun1→Fun2→Fun3 · `throw ex;` resets stack |
| 06 | Enums | `OrderStatus` · enum↔int · enum↔string · `Enum.IsDefined` before cast · GetValues · `: byte` |
| 07 | Arrays | 1D init · print · input · max + second max (start from `a[0]`) — **no 2D / jagged** |
| 08 | Methods | anatomy `Add` · returns · early `Score` · tuple `Stats` · optional `Connect` · overload `Max` · `=>` |

## Run

```bash
dotnet run --project 01-Nullable-Value-Types
dotnet run --project 02-Nullable-Reference-Types
dotnet run --project 03-Error-Types
dotnet run --project 04-Exception-Handling
dotnet run --project 05-Throw-Vs-ThrowEx
dotnet run --project 06-Enums
dotnet run --project 07-Arrays
dotnet run --project 08-Methods
```

Or open `Session03.sln` in Visual Studio.

## Style notes

- Classic `class Program` + `static void Main()`
- `<Nullable>enable</Nullable>` on every project
- Exception demos use built-in exception types only (no custom exception classes)
