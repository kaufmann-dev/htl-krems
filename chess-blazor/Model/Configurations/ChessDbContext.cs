using Microsoft.EntityFrameworkCore;
using Model.Entities.Armies;
using Model.Entities.Meeples;

namespace Model.Configurations; 

public class ChessDbContext : DbContext {

    public DbSet<Army> Armies { get; set; }
    public DbSet<AMeeple> Meeples { get; set; }
    public DbSet<King> Kings { get; set; }
    public DbSet<Queen> Queens { get; set; }
    public DbSet<Bishop> Bishops { get; set; }
    public DbSet<Rook> Rooks  { get; set; }
    public DbSet<Pawn> Pawns { get; set; }
    
    public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options) {
        
    }


    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<AMeeple>()
            .HasDiscriminator<string>("MEEPLE_TYPE")
            .HasValue<King>("KING")
            .HasValue<Queen>("QUEEN")
            .HasValue<Bishop>("BISHOP")
            .HasValue<Rook>("ROOK")
            .HasValue<Pawn>("PAWN");

        builder.Entity<AMeeple>()
            .HasOne(m => m.Army)
            .WithMany(a => a.Meeples)
            .HasForeignKey(m => m.ArmyId);


    }
}