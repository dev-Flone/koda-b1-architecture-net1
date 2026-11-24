namespace KodaCinema.Infrastructure.Configurations;

public class CorsSettings
{
    public const string SectionName = "Cors";

    public string PolicyName { get; set; } = "DefaulCorsPolicy";
    public string[] AllowedOrigins { get; set; } = [];
}