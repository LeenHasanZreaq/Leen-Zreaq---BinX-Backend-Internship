using Microsoft.EntityFrameworkCore;
using MyWebProject.week_3.Day4.Models;

namespace MyWebProject.week_3.Day4.Data;


public class Day4DbContext : DbContext
{
    public Day4DbContext(DbContextOptions<Day4DbContext> options)
        : base(options)
    {

    }

    public DbSet<Book> Books => Set<Book>();
}