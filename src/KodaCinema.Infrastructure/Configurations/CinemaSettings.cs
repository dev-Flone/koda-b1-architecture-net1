using System.ComponentModel.DataAnnotations;

namespace KodaCinema.Infrastructure.Configurations;

public class CinemaSettings
{
    public const string SectionName = "CinemaSettings";

    [Required(ErrorMessage = "Nama bioskop wajib diisi")] public string CinemaName { get; set; } = string.Empty;

    [Range(1, 20, ErrorMessage = "Maksimal kursi per pesanan adalah 1 - 20")]
    public int MaxSeatPerBooking { get; set; }

    [Range(5, 60)]
    public int BookingTimeoutMinutes { get; set; }

    public bool EnableOnlinePayment { get; set; }

}
