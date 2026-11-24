using KodaCinema.Application.DTOs.Movie.Response;
using KodaCinema.Application.Services.Interfaces;
using KodaCinema.Infrastructure.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace KodaCinema.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController(CinemaSettings cinemaSettings, ILogger<MovieController> logger, IMovieService service) : ControllerBase
{
    private readonly IMovieService _service = service;
    private readonly CinemaSettings _cinemaSettings = cinemaSettings;
    private readonly ILogger<MovieController> _logger = logger;

    [HttpGet]
    public async Task<ActionResult<List<MovieResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var movies = await _service.GetAllAsync(cancellationToken);

        return Ok(movies);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovieResponse>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var movie = await _service.GetByIdAsync(id, cancellationToken);

        if (movie is null) return Problem(
            statusCode: StatusCodes.Status404NotFound,
            title: "Movie Not Found",
            detail: $"Movie with ID {id} was not found"
        );

        return Ok(movie);
    }
}
