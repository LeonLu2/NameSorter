namespace NameSorter;

public class NameFileReader
{
    private readonly PersonNameParser _parser;

    public NameFileReader(PersonNameParser parser)
    {
        _parser = parser;
    }

    public IReadOnlyList<PersonName> Read(string filePath)
    {
        return File.ReadLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(_parser.Parse)
            .ToArray();
    }
}