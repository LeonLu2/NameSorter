namespace NameSorter;

public class PersonNameSorter
{
    private readonly IComparer<PersonName> _comparer;

    public PersonNameSorter(IComparer<PersonName> comparer)
    {
        _comparer = comparer;
    }

    public IReadOnlyList<PersonName> Sort(IEnumerable<PersonName> names)
    {
        return names
            .OrderBy(name => name, _comparer)
            .ToArray();
    }
}