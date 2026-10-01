# Session 01 — C# Basics Lecture 01

Companion demos for **C# Basics Lecture 01** (`CSharp_Basics_Lecture_01_updated.pptx`).

Only topics from this lecture are included.

## Deck

- `CSharp_Basics_Lecture_01_updated.pptx`

## Projects

| # | Project | Lecture topic |
|---|---------|----------------|
| 01 | Console-App | First console app · top-level statements |
| 02 | Namespaces | Namespaces · `using` · file-scoped namespace |
| 03 | Comments-And-Regions | `//` · `/* */` · `///` · `#region` |
| 04 | Variables-And-Types | Variables · signed/unsigned integers · float/double/decimal · bool/char/string |
| 05 | Value-And-Reference-Types | Value copy vs reference alias · struct / class |
| 06 | Stack-Method-Calls | Call stack PUSH / POP (`Add`) |
| 07 | Student-Object-On-Heap | `new Student()` on heap · shared references |
| 08 | Boxing-And-Unboxing | Stack value → heap box → unbox |
| 09 | Var-Object-Dynamic | `var` · `object` · `dynamic` |
| 10 | Operators | Arithmetic · `++`/`--` · integer division |
| 11 | Casting | Implicit/explicit · Convert · Parse · TryParse |

## Run

```bash
dotnet run --project 01-Console-App
dotnet run --project 04-Variables-And-Types
dotnet run --project 11-Casting
```

Or open `Session01.sln` in Visual Studio.

## Style rules (this lecture)

- Classic `class Program` + `static void Main()` — **no** top-level statements
- Do not use a topic before it is taught (e.g. no `TryParse` in Comments/Regions)
- Public fields in early demos — no properties yet
