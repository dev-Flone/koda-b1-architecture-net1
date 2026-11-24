using System.ComponentModel.DataAnnotations;

namespace KodaCinema.Application.DTOs.Movie.Request;

public record class CreateMovieRequest
{
    public long Id { get; init; }
    [Required] public string Name { get; init; } = string.Empty;
    [Required] public string Genre { get; init; } = string.Empty;
}
