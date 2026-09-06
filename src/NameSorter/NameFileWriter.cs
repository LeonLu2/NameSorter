namespace NameSorter;

public class NameFileWriter
{
    public void Write(string filePath, IEnumerable<PersonName> names)
    {
        File.WriteAllLines(
            filePath,
            names.Select(name => name.ToString()));
    }
}