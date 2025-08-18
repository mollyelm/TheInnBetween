using System;
using System.Collections.Generic;

namespace TibBackend.Models;

public class Seal
{
    // ----- Core Database Fields -----
    public int Id { get; set; }                         // Primary key
    public SealType Type { get; set; }                  // Type of seal (Standard, Fragile, etc.)
    public SealGrade Grade { get; set; }                // Grade indicating rarity or power
    public DateTime AppliedAt { get; set; }             // Timestamp when applied

    // ----- Foreign Keys / Relationships -----
    public int ParcelId { get; set; }                   // Parcel this seal belongs to
    public Parcel Parcel { get; set; }                  // Navigation property to parcel

    public int AppliedByUserId { get; set; }            // User who applied the seal
    public User AppliedBy { get; set; }                 // Navigation property to user
}

// ----- Enums -----
public enum SealType { Standard, Fragile, Urgent, Magical, Cursed }
public enum SealGrade { Common, Uncommon, Rare, Legendary }