namespace HealthHome.Models
{
    public class PatientMed
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Route { get; set; }
        public string? Dose { get; set; }
        public int PatientId { get; set; }
    }
}
