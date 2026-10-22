# Advanced C# - Lecture 05 — Unit Testing and Agile

Companion lab for `Testing_Agile_v11.pptx`.

Each example is **one file**. The class under test sits at the **end of that same file** (no extra production project).

## Run the tests

```bash
cd "3- Advanced C#/Lecture 5"
dotnet test AdvancedCsharp.Lecture05.slnx
```

| Folder | Deck topic | Class under test (bottom of the file) |
|--------|------------|----------------------------------------|
| `01_BankAccount` | First xUnit test + `Assert.Throws` | `BankAccount` |
| `02_InlineData` | Different input, different answer | `GradeCalculator` |
| `03_MemberData` | `MemberData` + `TheoryData` | `PriceCalculator` |
| `04_Shouldly` | Booleans, strings and null | `EmailValidator`, `TransferService` |
| `05_Bogus` | Hand-typed data is always "Mona" | `Customer` |
| `06_TimeProvider` | Pass time in (`TimeProvider`) | `ShopHours` |
| `07_TestDoubles` | Dummy, Fake, Spy, Stub, Mock | one example each |
| `08_Tdd` | Red, green, refactor | `Pricing` |

Packages from the deck: xUnit, Shouldly, Bogus, NSubstitute, `Microsoft.Extensions.TimeProvider.Testing`.
