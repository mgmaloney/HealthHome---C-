namespace HealthHome.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime DateTime { get; set; }
        public bool Read {  get; set; }
        public int ConversationId { get; set; }

    }
}
