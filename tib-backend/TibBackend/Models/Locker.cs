using System;
using System.Collections.Generic;

namespace TibBackend.Models;

public class Locker
{
    // ----- Core Database Fields -----
    public int Id { get; set; }                         // Primary key
    public string LockerNumber { get; set; }            // Identifier for locker
    public LockerSize Size { get; set; }                // Locker size
    public bool IsOccupied { get; set; } = false;      // Occupancy status
    public string? MagicalKeyCode { get; set; }         // Magical key code for tube system
    public LockerStatus Status { get; set; } = LockerStatus.Available; // Tracks cleaning or maintenance

    // ----- Navigation / Relationships -----
    public ICollection<Parcel> Parcels { get; set; } = new List<Parcel>(); // Parcels currently in this locker
}

// ----- Enums -----
public enum LockerSize { Small, Medium, Large }
public enum LockerStatus { Available, Occupied, NeedsCleaning, UnderMaintenance }