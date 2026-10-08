# Advanced C# - Lecture 03 — Concurrency, Tasks & Async

Companion lab for `Advanced_03_Concurrency_Async_Files_Testing.pptx` (full deck).

## Run

```bash
cd "3- Advanced C#/Lecture 3"
dotnet run --project AdvancedCsharp.Lecture03
```

Pick a **section**, then an **example** (same flow as Lecture 01 / 02).

## Sections

| # | Topic | Examples |
|---|--------|----------|
| 01 | Thread basics | thread id · create thread · two for-loops · Join + Sleep · foreground / background |
| 02 | Race & lock · Interlocked | flash sale · lock · lost update · Interlocked.Increment · if + Decrement race |
| 03 | Semaphore · deadlock | SemaphoreSlim kitchen · menuLock / stockLock |
| 04 | Concurrent collections | Dictionary / ConcurrentDictionary · Queue / ConcurrentQueue |
| 05 | ThreadPool | QueueUserWorkItem · reuse · starvation |
| 06 | Tasks | Task.Run · thread ids · Result · Wait · exceptions · Created/Start · lifecycle |
| 07 | Async / await | await vs Result · order · Sleep vs Delay · async void · sequential vs concurrent |
| 08 | Employee lab | Get/Add/Delete · UpdateSalaryAsync |
| 09 | Combinators | WhenAll · shared List · WhenAny timeout · WhenEach · exceptions |
| 10 | Cancellation | CTS · pass token · loop check · CancelAfter · upload cancel |
| 11 | Async pitfalls | ValueTask · async lambda · List.ForEach trap |
| 12 | Parallel | Parallel.For · ForEach · ForEachAsync · Parallel vs WhenAll |

## Slides

`Advanced_03_Concurrency_Async_Files_Testing.pptx`
