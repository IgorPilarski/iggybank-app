using Microsoft.EntityFrameworkCore;
using iggybank_app.Models;

namespace iggybank_app.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<User> Transactions { get; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}