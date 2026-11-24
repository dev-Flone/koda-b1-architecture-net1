using KodaCinema.Application.DTOs.Movie.Request;
using KodaCinema.Application.DTOs.Movie.Response;
using KodaCinema.Domain.Entity;
using KodaCinema.Infrastructure.Repositories.Interfaces;

namespace KodaCinema.Application.Services.Interfaces.Implementations;

public sealed class MovieService(IMovieRepository repository) : IMovieService
{
    public readonly IMovieRepository _repository = repository;
    public async Task<MovieResponse> CreatedAsync(CreateMovieRequest request, CancellationToken cancellationToken)
    {
        var movie = new Movie(
            request.Name,
            request.Genre
        );

        return MapToResponse(movie);
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var movie = await _repository.GetByIdAsync(id, cancellationToken);

        if (movie is null) return false;

        return true;
    }

    public async Task<List<MovieResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var movies = await _repository.GetAllAsync(cancellationToken);

        return [.. movies.Select(MapToResponse)];
    }

    public async Task<MovieResponse?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var movie = await _repository.GetByIdAsync(id, cancellationToken);

        return movie is null ? null : MapToResponse(movie);
    }

    public async Task<MovieResponse?> GetByName(string name, CancellationToken cancellationToken)
    {
        var movie = await _repository.GetByNameAsync(name, cancellationToken);

        return movie is null ? null : MapToResponse(movie);
    }

    // Helper
    private static MovieResponse MapToResponse(Movie movie)
    {
        return new MovieResponse
        {
            Id = movie.Id,
            Name = movie.Name,
            Genre = movie.Genre
        };
    }
}
