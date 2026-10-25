using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("XMR_RECEIVE_ADDRESSES")]
public class XmrReceiveAddress
{
    [Column("ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("ADDRESS")]
    [MinLength(95)]
    [MaxLength(106)]
    public string Address { get; set; }
    
    [Column("ADDED")]
    [DataType(DataType.DateTime)]
    public DateTime Added { get; set; }
    
    [Column("USER_ID")]
    public int UserId { get; set; }
    public User User { get; set; }
}