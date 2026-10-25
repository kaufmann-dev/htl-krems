using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("PGP_PUBLIC_KEYS")]
public class PgpPublicKey
{
    [Column("ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("KEY")]
    [Required]
    public string Key { get; set; }
    
    [Column("ACTIVE_DATE")]
    [Required]
    [DataType(DataType.Date)]
    public DateOnly ActiveDate { get; set; }
    
    [Column("ACTIVE")]
    [Required]
    public bool Active { get; set; }
    
    [Column("USER_ID")]
    public int UserId { get; set; }
    public User User { get; set; }
}