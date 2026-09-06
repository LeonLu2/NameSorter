namespace NameSorter.Tests;

public class PersonNameComparerTests
{
    private readonly PersonNameComparer _comparer = new();

    [Fact]
    public void Compare_DifferentLastNames_SortsByLastName()
    {
        PersonName parsons =
            new(new[] { "Janet" }, "Parsons");

        PersonName alvarez =
            new(new[] { "Marin" }, "Alvarez");

        int result = _comparer.Compare(parsons, alvarez);

        Assert.True(result > 0);
    }

    [Fact]
    public void Compare_SameLastName_SortsByFirstGivenName()
    {
        PersonName john =
            new(new[] { "John" }, "Smith");

        PersonName peter =
            new(new[] { "Peter" }, "Smith");

        int result = _comparer.Compare(john, peter);

        Assert.True(result < 0);
    }

    [Fact]
    public void Compare_SameFirstGivenName_SortsByNextGivenName()
    {
        PersonName adam =
            new(new[] { "John", "Adam" }, "Smith");

        PersonName bob =
            new(new[] { "John", "Bob" }, "Smith");

        int result = _comparer.Compare(adam, bob);

        Assert.True(result < 0);
    }

    [Fact]
    public void Compare_GivenNamesArePrefix_ShorterNameSortsFirst()
    {
        PersonName shorter =
            new(new[] { "John" }, "Smith");

        PersonName longer =
            new(new[] { "John", "Adam" }, "Smith");

        int result = _comparer.Compare(shorter, longer);

        Assert.True(result < 0);
    }

    [Fact]
    public void Compare_NamesDifferOnlyByCase_TreatsThemAsEqual()
    {
        PersonName first =
            new(new[] { "john" }, "smith");

        PersonName second =
            new(new[] { "John" }, "Smith");

        int result = _comparer.Compare(first, second);

        Assert.Equal(0, result);
    }
}