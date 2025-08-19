using System;

namespace TibBackend.Models;

public class ActionHistory
{
    // ----- Core Database Fields -----
    public int Id { get; set; }                         // Primary key
    public int UserId { get; set; }                     // Foreign key to User
    public int? ParcelId { get; set; }                  // Optional foreign key to Parcel
    public ActionType ActionType { get; set; }          // Enum describing the type of action
    public string? Description { get; set; }            // Optional extra context or notes
    public DateTime Timestamp { get; set; }             // When the action occurred

    // ----- Navigation Properties -----
    public User User { get; set; }                      // User who performed the action
    public Parcel? Parcel { get; set; }                 // Parcel involved in the action (if applicable)
}

// ----- Enum: Types of Actions -----
public enum ActionType
{
    Scan,
    ApplySeal,
    AssignLocker,
    DispatchKey,
    ReadLore,
    UnlockRole,
    Login,
    Logout,
    CleanLocker,
    FlagParcel,
    AdminOverride
}