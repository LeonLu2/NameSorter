namespace NameSorter.Tests;

public class NameFileWriterTests
{
    [Fact]
    public void Write_WritesNamesToFile()
    {
        string filePath = Path.GetTempFileName();

        try
        {
            PersonName[] names =
            {
                new(new[] { "Marin" }, "Alvarez"),
                new(new[] { "Janet" }, "Parsons")
            };

            NameFileWriter writer = new();

            writer.Write(filePath, names);

            string[] lines = File.ReadAllLines(filePath);

            Assert.Equal(
                new[]
                {
                    "Marin Alvarez",
                    "Janet Parsons"
                },
                lines);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void Write_ExistingFile_OverwritesContents()
    {
        string filePath = Path.GetTempFileName();

        try
        {
            File.WriteAllLines(
                filePath,
                new[]
                {
                    "Old Name",
                    "Another Old Name"
                });

            PersonName[] names =
            {
                new(new[] { "Marin" }, "Alvarez"),
                new(new[] { "Janet" }, "Parsons")
            };

            NameFileWriter writer = new();

            writer.Write(filePath, names);

            string[] lines = File.ReadAllLines(filePath);

            Assert.Equal(
                new[]
                {
                    "Marin Alvarez",
                    "Janet Parsons"
                },
                lines);
        }
        finally
        {
            File.Delete(filePath);
        }
    }
}