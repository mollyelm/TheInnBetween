using System;
using System.Collections.Generic;

namespace TibBackend.Models;

public class User
{
    // ----- Core Database Fields -----
    public int Id { get; set; }                         // Primary key
    public string Username { get; set; }                // Login identity
    public string Email { get; set; }                   // Contact/account recovery
    public string PasswordHash { get; set; }            // Authentication
    public DateTime CreatedAt { get; set; }             // Account creation timestamp
    public bool IsActive { get; set; } = true;         // Soft delete / account control

    // ----- Gameplay / Progression -----
    public UserRole? Role { get; set; }                // Current active role; null = start menu
    public bool IsAdminUnlocked { get; set; } = false; // Tracks role progression
    public bool IsDeliveryUnlocked { get; set; } = false
;
    public DateTime? LastLogin { get; set; }           // Optional last login timestamp

    // ----- UI / Profile Info -----
    public string DisplayName { get; set; }            // Shown in UI
    public string AvatarUrl { get; set; }              // Avatar image path or URL
    public string SettingsJson { get; set; }           // Flexible user settings (theme, preferences, etc.)

    // ----- Navigation / Relationships -----
    public ICollection<Parcel> CreatedParcels { get; set; } = new List<Parcel>(); // Parcels user has created
    public ICollection<ActionHistory> Actions { get; set; } = new List<ActionHistory>(); // Game/admin actions
    
    // Permanent tracking of scanned parcels (many-to-many)
    public ICollection<Parcel> ScannedParcels { get; set; } = new List<Parcel>();

    // ----- Session-only fields (not stored in DB) -----
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public bool IsOnShift { get; set; }                // Indicates if user is actively playing this session
}

// ----- Role Enum -----
public enum UserRole
{
    Clerk,
    Admin,
    Delivery
}
