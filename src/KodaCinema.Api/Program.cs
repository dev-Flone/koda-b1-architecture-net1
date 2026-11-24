using KodaCinema.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddDebug();
}

builder.Services.AddOptions<CinemaSettings>()
    .Bind(builder.Configuration.GetSection(CinemaSettings.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var cors = builder.Configuration.GetSection(CorsSettings.SectionName).Get<CorsSettings>() ?? new CorsSettings();

builder.Services.AddCors(options =>
{
    options.AddPolicy(cors.PolicyName, policy =>
    {
        policy.WithOrigins(cors.AllowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

app.MapGet("/", () => "Hello World!");

app.UseCors(cors.PolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.Run();
