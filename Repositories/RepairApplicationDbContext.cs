using Microsoft.EntityFrameworkCore;
using TechnicoApplication.Models;

namespace TechnicoApplication.Repositories;

public class RepairApplicationDbContext : DbContext{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Repair> Repairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=(local);Initial Catalog=Technico-Repair-Application; Integrated Security = True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    //Passing Parameters (extra) for properties(columns) of each of DbSet(tables to be) entities.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Owner>()
            .HasIndex(p => p.Email)
            .IsUnique();

        modelBuilder
            .Entity<Owner>()
            .HasIndex(p => p.VatNumber)
            .IsUnique();
    }
}
