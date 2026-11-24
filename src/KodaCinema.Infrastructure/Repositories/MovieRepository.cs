using System.Data.Common;
using KodaCinema.Domain.Entity;
using KodaCinema.Infrastructure.Context;
using KodaCinema.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KodaCinema.Infrastructure.Repositories.Implementations;

public sealed class MovieRepository(AppDbContext context) : IMovieRepository
{
    private readonly AppDbContext _context = context;
    public async Task AddAsync(Movie movie, CancellationToken cancellationToken)
    {
        await _context.Movies.AddAsync(movie, cancellationToken);
    }

    public void Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
    }

    public async Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Movies.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Movie?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task<Movie?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.Name == name, cancellationToken);
    }
}
