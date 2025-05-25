using Microsoft.EntityFrameworkCore;
using Finament.Domain.Entities;

namespace Finament.Repository.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users => Set<User>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Transaction-Tag many-to-many
        modelBuilder.Entity<Transaction>()
            .HasMany(t => t.Tags)
            .WithMany(t => t.Transactions)
            .UsingEntity(j => j.ToTable("TransactionTags"));

        // Category
        modelBuilder.Entity<Category>()
            .Property(c => c.Color)
            .HasDefaultValue("#FFFFFF");

        // Amount with precision (e.g. money)
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasColumnType("decimal(18,2)");
    }
}
