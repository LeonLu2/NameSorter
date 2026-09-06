# Name Sorter

A simple .NET console application that reads a list of names from a text file, sorts them by last name and then by given names, prints the sorted result to the console, and writes the result to `sorted-names-list.txt`.

## Requirements

- .NET 8 SDK

## Run

From the repository root:

```bash
dotnet run --project src/NameSorter -- ./unsorted-names-list.txt
```

The program will:

1. Read names from the provided input file.
2. Sort names by last name, then by given names.
3. Print the sorted names to the console.
4. Write or overwrite `sorted-names-list.txt` in the current working directory.

## Test

Run all tests with:

```bash
dotnet test
```

## Input Format

Each line should contain one name.

A valid name must contain:

- 1 to 3 given names
- 1 last name

Examples:

```text
Janet Parsons
Adonis Julius Archer
Hunter Uriah Mathew Clarke
```

## Assumptions

- The final word on each line is treated as the last name.
- Blank lines are ignored.
- Extra spaces between name parts are ignored.
- Sorting is case-insensitive.
- Duplicate names are preserved.
- Names with fewer than 1 or more than 3 given names are considered invalid.

## Project Structure

```text
src/NameSorter
tests/NameSorter.Tests
```

The solution separates parsing, sorting, file I/O, and application orchestration into small, focused classes.