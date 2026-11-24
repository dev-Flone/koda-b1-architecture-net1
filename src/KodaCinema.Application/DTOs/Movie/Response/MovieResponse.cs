namespace KodaCinema.Application.DTOs.Movie.Response;

public record class MovieResponse
{
    public long Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Genre { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}
