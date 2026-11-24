using KodaCinema.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace KodaCinema.Infrastructure.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
}