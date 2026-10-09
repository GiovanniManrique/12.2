# Assignment 12.2

A Visual Studio solution named **12.2**, with one C# console project per question.

| Project | Assignment question |
| --- | --- |
| **12.2.1** | Remove all linked-list nodes whose value equals `val` (LeetCode #203). |
| **12.2.2** | Explore the .NET MAUI learning path: runnable study companion and notes. |

## Open and run in Visual Studio

1. Open **12.2.sln**.
2. Right-click **12.2.1** or **12.2.2** in Solution Explorer and choose **Set as Startup Project**.
3. Press **Ctrl+F5** to run the selected program.

Requires the .NET 10 SDK and Visual Studio with .NET development support.

## Question 1

The program displays all three assignment examples, then accepts your own list and removal value. Enter comma-separated integers, optionally inside brackets; a blank list or `[]` means an empty list. Invalid input produces an explanatory message.

`RemoveElements` returns the updated linked-list head. A temporary dummy node handles removing the original head, consecutive matches, and removing every node. Matching nodes are skipped by changing `Next`; remaining nodes keep their original order and identity. The removal method takes **O(n) time** and **O(1) extra space**. Input construction and console formatting use additional memory.

Examples:

```text
[1,2,6,3,4,5,6], val = 6 -> [1,2,3,4,5]
[], val = 1             -> []
[7,7,7,7], val = 7      -> []
```

## Question 2

The assignment asks you to explore a learning path. **12.2.2 is a console study companion, not a MAUI app or a record of completed training.** Its `LearningNotes.txt` contains the study route, practice suggestions, and an unchecked personal checklist.

Use the official [Microsoft Learn .NET MAUI learning path](https://learn.microsoft.com/en-us/training/paths/build-apps-with-dotnet-maui/) for the actual hands-on exercises. Those exercises require the .NET MAUI workload. The two console projects in this solution do not require that workload.

## Terminal commands

From this folder:

```powershell
dotnet build 12.2.sln -c Release
dotnet run --project 12.2.1 -- --examples
dotnet run --project 12.2.1 -- "1,2,6,3,4,5,6" 6
dotnet run --project 12.2.1 -- "[]" 1
dotnet run --project 12.2.2
```

## GitHub

Only this assignment folder belongs in its repository. `.gitignore` excludes Visual Studio settings and generated build outputs.

## Verification

Both projects built in Release with zero warnings or errors. The linked-list method passed 1,012 cases covering the assignment examples, consecutive removals, no matches, empty lists, all matches, negative values, and 10,000-node lists. Checks confirmed that surviving nodes preserve their identity and order. Invalid console input was also checked, and the study companion ran successfully.
