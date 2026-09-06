namespace NameSorter;

/// <summary>
/// Parses a line of text into a <see cref="PersonName"/> using the final
/// token as the last name.
/// </summary>
public class PersonNameParser
{
    public PersonName Parse(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            throw new ArgumentException("Name must not be empty.", nameof(line));
        }

        string[] parts = line
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 2 || parts.Length > 4)
        {
            throw new FormatException(
                "A name must contain 1~3 given names, followed by a last name.");
        }

        string lastName = parts[^1];
        string[] givenNames = parts[..^1];

        return new PersonName(givenNames, lastName);
    }
}