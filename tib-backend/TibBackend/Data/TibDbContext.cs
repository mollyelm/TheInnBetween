using Microsoft.EntityFrameworkCore;
using TibBackend.Models;

namespace TibBackend.Data;

public class TibDbContext : DbContext
{
    public TibDbContext(DbContextOptions<TibDbContext> options)
        : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Npc> Npcs { get; set; }
    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<Locker> Lockers { get; set; }
    public DbSet<Seal> Seals { get; set; }
    public DbSet<ActionHistory> Actions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // relationships
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
        
        modelBuilder.Entity<Parcel>()
            .HasOne(p => p.ProcessedBy)
            .WithMany(u => u.ScannedParcels)
            .HasForeignKey(p => p.ProcessedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Parcel>()
            .HasOne(p => p.SenderNpc)
            .WithMany(n => n.SentParcels)
            .HasForeignKey(p => p.SenderNpcId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Parcel>()
            .HasOne(p => p.RecipientNpc)
            .WithMany(n => n.ReceivedParcels)
            .HasForeignKey(p => p.RecipientNpcId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Parcel>()
            .HasMany(p => p.Seals)
            .WithOne(s => s.Parcel)
            .HasForeignKey(s => s.ParcelId);

        modelBuilder.Entity<Seal>()
            .HasOne(s => s.AppliedBy)
            .WithMany(u => u.SealsApplied)
            .HasForeignKey(s => s.AppliedByUserId);

        modelBuilder.Entity<Locker>()
            .HasMany(l => l.Parcels)
            .WithOne(p => p.Locker)
            .HasForeignKey(p => p.LockerId);


    }
}