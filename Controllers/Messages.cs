using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HealthHome.Models;
using Microsoft.AspNetCore.Mvc;
using HealthHome___C_.Models.ViewModels;
using HealthHome;
using System.Net.Mail;
using HealthHome.Models.ViewModels;


namespace HealthHome.Controllers;

[ApiController]
[Route("messages")]

public class MessageController : ControllerBase
{
    private HealthHomeDbContext _dbContext;
    public MessageController(HealthHomeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult CreateMessage(MessageRequest messageRequest)
    {
        try
        {
            Conversation conversation = null;
            if (messageRequest.ConversationId == null)
            {
                conversation = _dbContext.Conversations.SingleOrDefault(c => c.Id == messageRequest.ConversationId);
            }
            else
            {
                var newConversation = new Conversation();
                conversation = _dbContext.Conversations.Add(newConversation).Entity;
                _dbContext.SaveChanges();
            }

            var newMessage = new Message
            {
                SenderId = messageRequest.SenderId,
                RecipientId = messageRequest.RecipientId,
                ConversationId = conversation.Id,
                DateTime = DateTime.Now,
                Read = false,
                Content = messageRequest.Content,
            };

            _dbContext.Add(newMessage);

            _dbContext.SaveChanges();
            return Ok(newMessage);
        }
        
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    [HttpPut("user_messages")]
    public IActionResult getUserMessages(MessageUserIdRequest messageUserIdRequest)
    {
        var messages = _dbContext.Messages.Where(m => m.SenderId == messageUserIdRequest.UserId || m.RecipientId == messageUserIdRequest.UserId);
        return Ok(messages.ToList());
    }

    [HttpPut("unread_messages_count")]
    public IActionResult getUserUnreadMessages(MessageUserIdRequest messageUserIdRequest)
    {
        var unreadMessages = _dbContext.Messages.Where(m => m.SenderId == messageUserIdRequest.UserId || m.RecipientId == messageUserIdRequest.UserId && !m.Read);
        int unreadMessagesCount = unreadMessages.Count();
        return Ok(unreadMessagesCount);
    }

    [HttpPut("read_message")]
    public IActionResult readMessage(ReadMessageRequest request)
    {
        var message = _dbContext.Messages.FirstOrDefault(m => m.Id == request.MessageId);
        message.Read = true;
        _dbContext.SaveChanges();
        return Ok();
    }

}
