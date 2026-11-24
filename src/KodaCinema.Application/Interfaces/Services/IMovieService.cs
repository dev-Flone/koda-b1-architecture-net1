using KodaCinema.Application.DTOs.Movie.Request;
using KodaCinema.Application.DTOs.Movie.Response;

namespace KodaCinema.Application.Services.Interfaces;

public interface IMovieService
{
    Task<List<MovieResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<MovieResponse?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<MovieResponse?> GetByName(string name, CancellationToken cancellationToken);
    Task<MovieResponse> CreatedAsync(CreateMovieRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}
