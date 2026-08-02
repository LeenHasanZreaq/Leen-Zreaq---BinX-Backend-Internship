using Microsoft.EntityFrameworkCore;
using week_3.Models;

namespace week_3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(b => b.Author)
                .HasMaxLength(100);

            entity.Property(b => b.Price)
                .HasPrecision(18, 2);

            entity.Property(b => b.PublishedDate)
                .IsRequired();
        });
    }
}
