namespace HealthHome___C_.Models.ViewModels
{
    public class MessageRequest
    {
        public int SenderId { get; set; }
        public string? Content { get; set; }
        public int RecipientId { get; set; }
        public int ConversationId { get; set; }

    }
}
