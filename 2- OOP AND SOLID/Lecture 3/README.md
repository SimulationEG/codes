# OOP Lecture 03 � Singleton � Copy � SRP � Relationships � Inheritance � Clinic

Companion demos for `OOP_Lecture_03_v10.pptx` � **folder numbers follow the deck order**.

## Runnable demos (presentation order)

| Project | Deck part | What it shows |
|---------|-----------|---------------|
| **`01-Singleton`** | Part 01 | Pain `new()` sprawl ? **Eager** / **Manual lazy** / **Lazy\<T\>** types |
| **`02-Copy-Shallow-Deep`** | Part 02 | Reference assign � shallow � deep � records note |
| **`03-SOLID-SRP`** | Part 03 | One `Order` example: 3 fields + 10 methods ? keep 2, extract 3/3/2; **no interfaces** |
| **`04-Relationships`** | Part 04 | Association / aggregation / composition / dependency |
| **`05-Inheritance-Basics`** | Part 05 | Shared base, ctor order, `new` vs `virtual`/`override` (5 short steps) |
| **`06-Access-Lib` + `06-Access-App`** | Part 05 | All modifiers: same/outside assembly � then with inheritance same/outside |
| **`07-Inheritance-Problems`** | Part 05 | Fragile base � one-parent limit � feature pollution |
| **`10-Clinic-App`** | Capstone | Mini domain put-together |

UML diagram slides are taught from the deck � no extra UML-only demos beyond `04-Relationships`.

## Build / run

```bash
dotnet build Lecture03.sln
dotnet run --project 01-Singleton
dotnet run --project 02-Copy-Shallow-Deep
dotnet run --project 03-SOLID-SRP
dotnet run --project 04-Relationships
dotnet run --project 05-Inheritance-Basics
dotnet run --project 06-Access-App
dotnet run --project 07-Inheritance-Problems
dotnet run --project 10-Clinic-App
```

## Regenerate slides (optional)

```bash
cd generator
npm run generate
```
