using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Armies;

namespace Model.Entities.Meeples; 

[Table("MEEPLES")]
public abstract class AMeeple {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MEEPLE_ID")]
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Column("IMAGE_URL")]
    public string Url { get; set; }

    [Required, Range(0,7)]
    [Column("ROW_INDEX")]
    public int X { get; set; }

    [Required, Range(0,7)]
    [Column("COLUMN_INDEX")]
    public int Y { get; set; }
    
    [Column("ARMY_ID")]
    public int? ArmyId { get; set; }

    public Army? Army { get; set; }

    protected AMeeple() {
        
    }

    protected AMeeple(string url, int x, int y) {
        Url = url;
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"Id: {Id}\n";
    }
}