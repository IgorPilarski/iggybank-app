using Microsoft.EntityFrameworkCore;
using iggybank_app.Models;

namespace iggybank_app.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}