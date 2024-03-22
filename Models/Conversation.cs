namespace HealthHome.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public ICollection<Message> ConversationMessages { get; set; }
    }
}
