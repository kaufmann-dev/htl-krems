using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Meeples;

namespace Model.Entities.Armies; 

[Table("ARMIES")]
public class Army {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ARMY_ID")]
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Column("LABEL")]
    public string Label { get; set; }

    
    public List<AMeeple>? Meeples { get; set; }
}