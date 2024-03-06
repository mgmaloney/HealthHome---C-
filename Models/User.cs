using System.ComponentModel.DataAnnotations;

namespace HealthHome.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Birthdate { get; set; }
        public string? Ssn { get; set; }
        public string? Gender {  get; set; }
        public string? Sex { get; set; }
        public string? Credential { get; set; }
        public bool Admin {  get; set; }
        public bool Provider {  get; set; }
    }
}