namespace Pract_6_Demin.Service
{
    public class FMovie
    {
        public string? Title { get; set; } = null!;

        public string? Genre { get; set; } = null!;

        public int? DurationMinutes { get; set; } = null;

        public int? ReleaseYear { get; set; } = null;

        public bool? IsAvailable { get; set; } = null;
    }
}
