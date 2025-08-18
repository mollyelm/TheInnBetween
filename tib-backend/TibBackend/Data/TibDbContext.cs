using Microsoft.EntityFrameworkCore;
using TibBackend.Models;

namespace TibBackend.Data;

public class TibDbContext : DbContext
{
    public TibDbContext(DbContextOptions<TibDbContext> options)
        : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<Locker> Lockers { get; set; }
    public DbSet<Seal> Seals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // relationships
        modelBuilder.Entity<Parcel>()
            .HasOne(p => p.CreatedBy)
            .WithMany(u => u.CreatedParcels)
            .HasForeignKey(p => p.CreatedByUserId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Locker>()
            .HasIndex(l => l.LockerNumber)
            .IsUnique();

        modelBuilder.Entity<Locker>().HasData(
            Enumerable.Range(1, 20).Select(i => new Locker
            {
                Id = i,
                LockerNumber = $"L{i:D3}",
                Size = (LockerSize)(i % 3),
                IsOccupied = false
            })
        );
    }
}