namespace NameSorter.Tests;

public class PersonNameParserTests
{
    private readonly PersonNameParser _parser = new();

    [Fact]
    public void Parse_TwoPartName_ReturnsGivenAndLastName()
    {
        PersonName result = _parser.Parse("Janet Parsons");

        Assert.Single(result.GivenNames);
        Assert.Equal("Janet", result.GivenNames[0]);
        Assert.Equal("Parsons", result.LastName);
    }

    [Fact]
    public void Parse_MultipleGivenNames_ReturnsAllGivenNames()
    {
        PersonName result = _parser.Parse("Hunter Uriah Mathew Clarke");

        Assert.Equal(
            new[] { "Hunter", "Uriah", "Mathew" },
            result.GivenNames);

        Assert.Equal("Clarke", result.LastName);
    }

    [Fact]
    public void Parse_MoreThanThreeGivenNames_ThrowsFormatException()
    {
        Assert.Throws<FormatException>(
            () => _parser.Parse("A B C D Smith"));
    }

    [Fact]
    public void Parse_MultipleSpaces_IgnoresExtraWhitespace()
    {
        PersonName result = _parser.Parse("Hunter   Uriah   Clarke");

        Assert.Equal(
            new[] { "Hunter", "Uriah" },
            result.GivenNames);

        Assert.Equal("Clarke", result.LastName);
    }

    [Fact]
    public void Parse_EmptyInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => _parser.Parse(""));
    }

    [Fact]
    public void Parse_OnlyOneName_ThrowsFormatException()
    {
        Assert.Throws<FormatException>(
            () => _parser.Parse("Janet"));
    }
}