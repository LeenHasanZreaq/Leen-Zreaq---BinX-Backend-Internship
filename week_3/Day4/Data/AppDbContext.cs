using Microsoft.EntityFrameworkCore;
using MyWebProject.week_3.Day4.Models;

namespace MyWebProject.week_3.Day4.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public DbSet<Book> Books => Set<Book>();
}