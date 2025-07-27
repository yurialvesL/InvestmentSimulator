using InvestmentSimulator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentSimulator.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Investment>()
            .HasOne(i => i.User)
            .WithMany(u => u.Investments)
            .HasForeignKey(i => i.UserId);

        modelBuilder.Entity<Investment>(entity =>
        {
            entity.Property(x => x.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });


        modelBuilder.Entity<User>()
            .HasMany(u => u.Investments)
            .WithOne(i => i.User)
            .HasForeignKey(i => i.UserId);

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(x => x.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
    
    public DbSet<Investment> Investments { get; set; }
    public DbSet<User> Users { get; set; }
}
