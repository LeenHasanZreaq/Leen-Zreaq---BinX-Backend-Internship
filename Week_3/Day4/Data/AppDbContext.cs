using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebProject.week_3.Day4.Models;
using MyWebProject.Models;

namespace MyWebProject.week_3.Day4.Data;

public class Day4DbContext : IdentityDbContext<IdentityUser>
{
    public Day4DbContext(DbContextOptions<Day4DbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<MyWebProject.Models.Book> BookStore => Set<MyWebProject.Models.Book>();
    public DbSet<User> AppUsers => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(builder =>
        {
            builder.Property(b => b.Price)
                   .HasPrecision(18, 2);
        });

        modelBuilder.Entity<MyWebProject.Models.Book>(builder =>
        {
            builder.Property(b => b.Price)
                   .HasPrecision(18, 2);
        });

        base.OnModelCreating(modelBuilder);
    }
}