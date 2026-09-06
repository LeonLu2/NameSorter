using NameSorter;

if (args.Length != 1)
{
    Console.Error.WriteLine(
        "Usage: name-sorter <path-to-unsorted-names-list>");
    return 1;
}

string inputFilePath = args[0];

if (!File.Exists(inputFilePath))
{
    Console.Error.WriteLine(
        $"Input file not found: {inputFilePath}");
    return 1;
}

try
{
    PersonNameParser parser = new();

    NameFileReader reader = new(parser);

    PersonNameComparer comparer = new();

    PersonNameSorter sorter = new(comparer);

    NameFileWriter writer = new();

    IReadOnlyList<PersonName> names =
        reader.Read(inputFilePath);

    IReadOnlyList<PersonName> sortedNames =
        sorter.Sort(names);

    foreach (PersonName name in sortedNames)
    {
        Console.WriteLine(name);
    }

    string outputFilePath = Path.Combine(
        Directory.GetCurrentDirectory(),
        "sorted-names-list.txt");

    writer.Write(outputFilePath, sortedNames);

    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}
