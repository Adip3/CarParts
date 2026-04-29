using Microsoft.EntityFrameworkCore;
using VehicleParts.API.Models;

namespace VehicleParts.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
}
