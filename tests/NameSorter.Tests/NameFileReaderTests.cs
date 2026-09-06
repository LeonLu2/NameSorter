namespace NameSorter.Tests;

public class NameFileReaderTests
{
    [Fact]
    public void Read_ValidFile_ReturnsParsedNames()
    {
        string filePath = Path.GetTempFileName();

        try
        {
            File.WriteAllLines(
                filePath,
                new[]
                {
                    "Janet Parsons",
                    "Hunter Uriah Mathew Clarke"
                });

            NameFileReader reader =
                new(new PersonNameParser());

            IReadOnlyList<PersonName> result =
                reader.Read(filePath);

            Assert.Equal(2, result.Count);
            Assert.Equal("Janet Parsons", result[0].ToString());
            Assert.Equal(
                "Hunter Uriah Mathew Clarke",
                result[1].ToString());
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void Read_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        string filePath = Path.Combine(
            Path.GetTempPath(),
            $"{Guid.NewGuid()}.txt");

        NameFileReader reader =
            new(new PersonNameParser());

        Assert.Throws<FileNotFoundException>(
            () => reader.Read(filePath));
    }

    [Fact]
    public void Read_BlankLines_IgnoresBlankLines()
    {
        string filePath = Path.GetTempFileName();

        try
        {
            File.WriteAllLines(
                filePath,
                new[]
                {
                    "Janet Parsons",
                    "",
                    "   ",
                    "Marin Alvarez"
                });

            NameFileReader reader =
                new(new PersonNameParser());

            IReadOnlyList<PersonName> result =
                reader.Read(filePath);

            Assert.Equal(2, result.Count);
            Assert.Equal("Janet Parsons", result[0].ToString());
            Assert.Equal("Marin Alvarez", result[1].ToString());
        }
        finally
        {
            File.Delete(filePath);
        }
    }
}