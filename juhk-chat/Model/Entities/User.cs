using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Model.Entities;

[Table("USERS")]
public class User
{
    [Column("ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("NAME")]
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    
    [Column("TAG")]
    [Required]
    [StringLength(15)]
    public string Tag { get; set; }
    
    [Column("PASSWORD")]
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Column("CREATION_DATE")]
    [DataType(DataType.DateTime)]
    public DateTime CreationDate { get; set; }
    
    [Column("XMR_ACTIVE")]
    [Required]
    public bool XmrActive { get; set; }
    
    [Column("PGP_ACTIVE")]
    [Required]
    public bool PgpActive { get; set; }

    public List<ChatUsers> Chats { get; set; } = new ();
}