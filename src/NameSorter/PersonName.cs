namespace NameSorter;

/// <summary>
/// Represents a person's name as one to three given names and a last name.
/// </summary>
public class PersonName
{
    public IReadOnlyList<string> GivenNames { get; }
    public string LastName { get; }

    public PersonName(IEnumerable<string> givenNames, string lastName)
    {
        GivenNames = givenNames.ToArray();
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{string.Join(" ", GivenNames)} {LastName}";
    }
}