using HealthHome.Models;
using HealthHome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthHome.Controllers;

[ApiController]
[Route("/conversations")]
public class ConversationController : ControllerBase
{
    private HealthHomeDbContext _dbContext;

    public ConversationController(HealthHomeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPut("get_conversations")]
    public IActionResult getConversations(ConversationRequest request)
    {
        var distinctConversationsWithLatestMessage = _dbContext.Messages.Where(m => m.SenderId == request.UserId || m.RecipientId == request.UserId).GroupBy(m => m.ConversationId).Select(g => new
        {
            ConversationId = g.Key,
            LatestMessage = g.OrderByDescending(m => m.DateTime).FirstOrDefault(),
            Sender = _dbContext.Users.FirstOrDefault(u => u.Id == g.OrderByDescending(m => m.DateTime).FirstOrDefault().SenderId),
            Recipient = _dbContext.Users.FirstOrDefault(u => u.Id == g.OrderByDescending(m => m.DateTime).FirstOrDefault().RecipientId)
        }).ToList();
        //var messages = _dbContext.Messages.Where(m => m.SenderId == request.UserId || m.RecipientId == request.UserId)
        //    .OrderBy(m => m.DateTime).ToList();

        //var conversationIds = messages.Select(m => m.ConversationId).Distinct().ToList();

        //var conversations = _dbContext.Conversations.Where(c => conversationIds.Contains(c.Id)).ToList();

        //List<MultiConversationDto> conversationsList = new List<MultiConversationDto>();

        //foreach (var conversation in conversations)
        //{
        //    var conversationWithMessages = conversation.ConversationMessages.Select(m => new MessageWithSenderAndRecipient
        //    {
        //        Content = m.Content,
        //        Sender = _dbContext.Users.FirstOrDefault(u => u.Id == m.SenderId),
        //        Recipient = _dbContext.Users.FirstOrDefault(u => u.Id == m.RecipientId)
        //    }).ToList();
        //    conversationsList.Add(new MultiConversationDto
        //    {
        //        Conversation = conversation,
        //        Messages = conversationWithMessages
        //    });
        //}


        //return Ok(conversationsList);

        return Ok(distinctConversationsWithLatestMessage);
    }

    [HttpPut("get_single_conversation")]
    public IActionResult getSingleConversation(SingleConversationRequest request)
    {
        var messages = _dbContext.Messages.Where(m => (m.SenderId == request.UserId && m.RecipientId == request.RecipientId) || (m.SenderId == request.RecipientId && m.RecipientId == request.UserId))
            .OrderBy(m => m.DateTime).ToList();
        var conversation = _dbContext.Conversations.FirstOrDefault(c => c.Id == messages[0].ConversationId);

        var conversationMessagesWithSendersAndRecipients = messages.Select(m => new MessageWithSenderAndRecipient
        {
            Content = m.Content,
            Sender = _dbContext.Users.FirstOrDefault(u => u.Id == m.SenderId),
            Recipient = _dbContext.Users.FirstOrDefault(u => u.Id == m.RecipientId)
        }).ToList();

        var conversationDto = new SingleConversationDto
        {
            ConversationMessages = messages.OrderByDescending(m => m.DateTime).ToList()
        };


        return Ok(new { ConversationMessages = conversationMessagesWithSendersAndRecipients });
    }

    public class SingleConversationDto
    {
     
        public List<Message> ConversationMessages { get; set; }
    }

    public class MultiConversationDto
    {
        public Conversation Conversation { get; set; }
        public List<MessageWithSenderAndRecipient> Messages { get; set; }
    }


    public class MessageWithSenderAndRecipient
    {
        public string Content { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }
    }
}

