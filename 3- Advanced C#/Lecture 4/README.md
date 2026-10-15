# Advanced C# - Lecture 04 — Async · Files · JSON · Unit Testing

Companion lab for `Advanced_03_Concurrency_Async_Revision.pptx`
(from **Task vs ValueTask** through **unit testing** examples).

## Run demos

```bash
cd "3- Advanced C#/Lecture 4"
dotnet run --project AdvancedCsharp.Lecture04
```

Pick a **section**, then an **example** (same flow as Lecture 01–03).

Section **09 · Unit testing** prints a map, then each example runs the matching
`dotnet test --filter` so the PPT topics stay clear.

## Run all unit tests

```bash
cd "3- Advanced C#/Lecture 4"
dotnet test AdvancedCsharp.Lecture04.slnx
```

| Tests folder | PPT topic | Class under test |
|--------------|-----------|------------------|
| `01_ArrangeActAssert` | Arrange / Act / Assert + `Assert.Throws` | `BankAccount` |
| `02_TheoryInlineData` | `[Fact]` / `[Theory]` / `[InlineData]` | `EmailValidator`, `GradeCalculator` |
| `03_MemberData` | `TheoryData` for decimals | `PriceCalculator` |
| `04_Boundaries` | ages just below / at / above limits | `TicketPricer` |
| `05_AsyncAndLifecycle` | `async Task` + ctor / `Dispose` | `FileEmployeeRepository` |
| `06_TestableCode` | no flaky static/random; `FakeTimeProvider` | `Invoice`, `ShopHours` |
| `07_TestDoubles` | Fake / Spy / Dummy + NSubstitute | `TransferService`, `CurrencyConverter`, `ReceiptService` |
| `08_Libraries` | Shouldly + Bogus (seeded) | `Customer` + validators |
| `09_Tdd` | Loyalty points TDD kata | `LoyaltyCalculator` |

Classes under test: `AdvancedCsharp.Lecture04.Core`  
Test packages (from the deck): xUnit, NSubstitute, Shouldly, Bogus, `Microsoft.Extensions.TimeProvider.Testing`

SwiftBite labs (later deck slides) stay in https://github.com/SimulationEG/SwiftBite

## Demo sections

| # | Topic |
|---|--------|
| 01 | Task vs ValueTask |
| 02 | WhenAll / WhenAny / WhenEach |
| 03 | Cancellation |
| 04 | Parallel family |
| 05 | Files & paths |
| 06 | Streams |
| 07 | JSON & serialization |
| 08 | Final project · generic `JsonStore<T>` (async + FileStream) |
| 09 | Unit testing (map + filtered `dotnet test`) |

## Slides

`Advanced_03_Concurrency_Async_Revision.pptx`
