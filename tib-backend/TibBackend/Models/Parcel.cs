using System;
using System.Collections.Generic;

namespace TibBackend.Models;

public class Parcel
{
    // ----- Core Database Fields -----
    public int Id { get; set; }                         // Primary key
    public string TrackingNumber { get; set; }          // Unique parcel identifier
    public string SenderName { get; set; }              // NPC sender
    public int? SenderLocationId { get; set; }          // Optional sender location reference
    public string RecipientName { get; set; }           // Resident or NPC recipient
    public int? RecipientLocationId { get; set; }       // Optional recipient location reference
    public ParcelSize Size { get; set; }                // Parcel size category
    public ParcelStatus Status { get; set; }            // Current parcel status
    public string? Notes { get; set; }                  // Optional notes
    public string? LoreContent { get; set; }            // Optional story/lore associated with parcel

    // ----- Timestamps -----
    public DateTime ReceivedAt { get; set; }            // When parcel arrived at inn
    public DateTime? ScannedAt { get; set; }            // When parcel was scanned by clerk/admin
    public DateTime? DeliveredAt { get; set; }          // When parcel was delivered

    // ----- Locker Assignment -----
    public int? LockerId { get; set; }                  // Assigned locker
    public Locker? Locker { get; set; }                 // Navigation property to locker

    // ----- Processing / User Actions -----
    public int? ProcessedByUserId { get; set; }         // User who scanned or processed the parcel
    public User? ProcessedBy { get; set; }             // Navigation property to user

    // ----- Navigation / Relationships -----
    public ICollection<Seal> Seals { get; set; } = new List<Seal>();           // Magical seals applied
    public ICollection<ActionHistory> Actions { get; set; } = new List<ActionHistory>(); // Parcel event history
}

public enum ParcelSize { Small, Medium, Large, Oversized }
public enum ParcelStatus { Received, InLocker, Scanned, Delivered }