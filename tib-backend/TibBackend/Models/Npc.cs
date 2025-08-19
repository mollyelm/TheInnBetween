using System;
using System.Collections.Generic;

namespace TibBackend.Models;

public class Npc
{
    // ----- Core Fields -----
    public int Id { get; set; }                    // Primary Key
    public string Name { get; set; }               // Display name (e.g., "Thoma", "Miss Juniper")
    public string? Nickname { get; set; }          // Optional friendly nickname or title
    public string? Description { get; set; }       // Short lore description or personality

    // ----- World Info -----
    public string? Location { get; set; }          // City, store, or inn room
    public string? Affiliation { get; set; }       // Store owner, clerk at X, etc.

    // ----- Visual / UI -----
    public string? PortraitUrl { get; set; }       // Path to image asset
    public string? ThemeColor { get; set; }        // Optional UI theming

    // ----- Navigation -----
    public ICollection<Parcel> SentParcels { get; set; } = new List<Parcel>();
    public ICollection<Parcel> ReceivedParcels { get; set; } = new List<Parcel>();
}