using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class JUHKDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatUsers> ChatUsers { get; set; }

    public JUHKDbContext(DbContextOptions<JUHKDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasIndex(u => u.Tag).IsUnique();

        builder.Entity<PgpPublicKey>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.Entity<XmrReceiveAddress>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.Entity<ChatUsers>()
            .HasKey(cu => new { cu.ChatId, cu.UserId });
        
        builder.Entity<ChatUsers>()
            .HasOne(ba => ba.User)
            .WithMany(u=>u.Chats)
            .HasForeignKey(ba => ba.UserId);
        
        builder.Entity<ChatUsers>()
            .HasOne(ba => ba.Chat)
            .WithMany()
            .HasForeignKey(ba => ba.ChatId);

    }
}