namespace HealthHome.Models
{
    public class Allergy
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Severity { get; set; }
        public string? Reaction { get; set; }
        public int? PatientId { get; set; }
    }
}
