using Microsoft.EntityFrameworkCore;
using CustomersApi.Domain;

namespace CustomersApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
            .HasKey(a => new { a.Id });
    }
}