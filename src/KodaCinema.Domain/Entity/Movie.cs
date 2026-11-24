using System.Data.Common;

namespace KodaCinema.Domain.Entity;

public class Movie(string name, string genre)
{
    public long Id { get; private set; }
    public string Name { get; private set; } = name;
    public string Genre { get; private set; } = genre;
}
