using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("PUBLIC_PGP_KEYS")]
public class PublicPgpKey
{
    [Column("ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("KEY")]
    [DataType(DataType.Text)]
    public string Key { get; set; }
    
    [Column("ADDED")]
    [DataType(DataType.DateTime)]
    public DateTime Added { get; set; }
    
    [Key]
    [Column("USER_ID")]
    public int UserId { get; set; }
    public User User { get; set; }
}