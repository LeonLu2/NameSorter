namespace NameSorter;

/// <summary>
/// Compares names by last name first, then lexicographically by given names.
/// </summary>
public class PersonNameComparer : IComparer<PersonName>
{
    private readonly StringComparer _stringComparer = StringComparer.OrdinalIgnoreCase;

    public int Compare(PersonName? x, PersonName? y)
    {
        if (ReferenceEquals(x, y))
        {
            return 0;
        }

        if (x is null)
        {
            return -1;
        }

        if (y is null)
        {
            return 1;
        }

        int lastNameComparison =
            _stringComparer.Compare(x.LastName, y.LastName);

        if (lastNameComparison != 0)
        {
            return lastNameComparison;
        }

        int commonLength =
            Math.Min(x.GivenNames.Count, y.GivenNames.Count);

        for (int i = 0; i < commonLength; i++)
        {
            int givenNameComparison =
                _stringComparer.Compare(
                    x.GivenNames[i],
                    y.GivenNames[i]);

            if (givenNameComparison != 0)
            {
                return givenNameComparison;
            }
        }

        return x.GivenNames.Count.CompareTo(y.GivenNames.Count);
    }
}