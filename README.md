# The Inn Between

**The Inn Between** is a full-stack web application that combines narrative storytelling with interactive parcel management in a fantastical inn setting. Players step into the roles of magical inn staff — clerks, admins, and eventually delivery personnel — managing parcels, lockers, and enchanted seals while uncovering the hidden lore of the inn’s residents and visitors.

---

## Project Concept

At the heart of TIB is the magical inn, a hub of communication and commerce in a fantasy city. Parcels arrive daily, each carrying not only physical items but also stories and secrets. Players interact with the inn through three main roles:

- **Clerk:** Receives parcels, records label information, and applies magical seals of varying types and grades. Clerks assign parcels to lockers based on size, urgency, and ownership, initiating the magical key system that delivers items to residents.
- **Admin:** Performs magical scanning to inspect parcels, uncovering hidden lore. Admins oversee locker assignments and can unlock narrative elements tied to parcels, enriching the player experience.
- **Delivery (Future Role):** Delivers parcels to other residents and manages outbound items, connecting the inn to the wider city and its network of businesses and characters.

The game emphasizes **full-stack functionality with narrative integration**, blending utility (parcel management, locker assignments, key delivery) with discovery and storytelling. Parcels often have attached notes, magical labels, and lore-specific content, allowing each interaction to feel purposeful and immersive. The system balances structured backend data management with a rich front-end interface that invites exploration.

---

## Technical Stack

TIB leverages modern web development frameworks and cloud technologies to create a robust, scalable, and maintainable system:

- **Backend:** ASP.NET 8 / C# — Handles all server-side logic, database communication, and role-based functionality.
- **Frontend:** React — Provides dynamic, interactive pages for parcel management, character selection, and narrative exploration.
- **Database:** AWS RDS (PostgreSQL) — Stores users, parcels, lockers, and action histories with relational integrity.
- **ORM:** Entity Framework Core — Simplifies database interactions with an object-relational mapping layer.
- **Real-time / Messaging:** SignalR — Supports future real-time updates for parcel status and locker notifications.
- **Task Scheduling:** Hangfire — Manages scheduled tasks like parcel inspections, maintenance, or role unlocks.
- **Styling:** Tailwind CSS — Ensures clean, responsive, and maintainable UI across pages.
- **Hosting / Cloud:** AWS (RDS, S3 for assets, optional EC2 for backend hosting) — Provides secure and scalable cloud infrastructure.

The system is designed to highlight **full-stack competence**, with the backend providing robust business logic and data integrity while the frontend delivers an immersive, interactive user experience.

---

## Narrative Integration

The game is designed to **weave utility and story together**: each parcel may have narrative significance, each locker assignment contributes to gameplay strategy, and every role offers unique ways to explore the inn’s residents, visitors, and magical systems. This ensures that even standard backend operations, like inserting and querying parcels, contribute meaningfully to the player’s experience.

