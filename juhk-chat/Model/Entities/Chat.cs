using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("CHATS")]
public class Chat
{
    [Column("ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("NAME")]
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    
    [Column("AUTO_DELETE_DURATION")]
    [MinLength(1), MaxLength(31536000)]
    public int AutoDeleteDuration { get; set; }
    
    [Column("PGP_ENFORCEMENT")]
    [Required]
    public bool PgpEnforcement { get; set; }
}