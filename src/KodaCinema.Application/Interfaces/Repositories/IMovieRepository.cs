using KodaCinema.Domain.Entity;

namespace KodaCinema.Infrastructure.Repositories.Interfaces;

public interface IMovieRepository
{
    Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken);
    Task<Movie?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<Movie?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task AddAsync(Movie movie, CancellationToken cancellationToken);
    void Delete(Movie movie);
}
