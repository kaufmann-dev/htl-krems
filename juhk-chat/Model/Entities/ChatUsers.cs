using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("USER_SUBSCRIBED_CHATS")]
public class ChatUsers
{
    [Column("USER_ID")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [Column("CHAT_ID")]
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
}