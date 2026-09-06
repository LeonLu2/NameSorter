namespace NameSorter.Tests;

public class NameSorterTests
{
    private readonly PersonNameSorter _sorter =
        new(new PersonNameComparer());

    [Fact]
    public void Sort_OfficialExample_ReturnsExpectedOrder()
    {
        PersonName[] names =
        {
            new(new[] { "Janet" }, "Parsons"),
            new(new[] { "Vaughn" }, "Lewis"),
            new(new[] { "Adonis", "Julius" }, "Archer"),
            new(new[] { "Shelby", "Nathan" }, "Yoder"),
            new(new[] { "Marin" }, "Alvarez"),
            new(new[] { "London" }, "Lindsey"),
            new(new[] { "Beau", "Tristan" }, "Bentley"),
            new(new[] { "Leo" }, "Gardner"),
            new(new[] { "Hunter", "Uriah", "Mathew" }, "Clarke"),
            new(new[] { "Mikayla" }, "Lopez"),
            new(new[] { "Frankie", "Conner" }, "Ritter")
        };

        IReadOnlyList<PersonName> result = _sorter.Sort(names);

        Assert.Equal(
            new[]
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder"
            },
            result.Select(name => name.ToString()));
    }

    [Fact]
    public void Sort_SameLastName_SortsByAllGivenNames()
    {
        PersonName[] names =
        {
            new(new[] { "John", "Brian" }, "Smith"),
            new(new[] { "James" }, "Smith"),
            new(new[] { "John" }, "Smith"),
            new(new[] { "Jacob" }, "Smith"),
            new(new[] { "John", "Adam" }, "Smith"),
            new(new[] { "James", "Robert" }, "Smith"),
            new(new[] { "James", "Alan" }, "Smith")
        };

        IReadOnlyList<PersonName> result = _sorter.Sort(names);

        Assert.Equal(
            new[]
            {
                "Jacob Smith",
                "James Smith",
                "James Alan Smith",
                "James Robert Smith",
                "John Smith",
                "John Adam Smith",
                "John Brian Smith"
            },
            result.Select(name => name.ToString()));
    }

    [Fact]
    public void Sort_DuplicateNames_PreservesDuplicates()
    {
        PersonName[] names =
        {
            new(new[] { "James" }, "Smith"),
            new(new[] { "Jacob" }, "Smith"),
            new(new[] { "James" }, "Smith")
        };

        IReadOnlyList<PersonName> result = _sorter.Sort(names);

        Assert.Equal(
            new[]
            {
                "Jacob Smith",
                "James Smith",
                "James Smith"
            },
            result.Select(name => name.ToString()));
    }
}