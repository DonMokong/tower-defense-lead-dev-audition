# Tower Defense Prototype – Technical Design Document

## Overview

This project implements a simplified tower defense prototype designed to demonstrate clean architecture, maintainable code structure, and data-driven gameplay systems. The goal is not feature completeness but creating a foundation that a team could easily extend.

The implementation prioritizes **clarity, extensibility, and separation of concerns** rather than visual polish.

---

## Architecture Overview

The project follows a modular architecture with clear separation between gameplay systems.

Core systems include:

* **GameManager** – Handles global game state such as score tracking and base health.
* **EnemyManager** – Maintains a list of active enemies so other systems can query enemies efficiently.
* **EnemyController** – Controls enemy movement, damage handling, and lifecycle events.
* **TowerBase** – Abstract base class containing shared tower behavior such as firing logic and enemy detection.
* **Projectile** – Responsible for moving toward a target and applying damage.

Gameplay configuration such as enemy statistics is stored in **ScriptableObjects**, allowing designers to tweak balance without modifying gameplay logic.

---

## Class Structure

### GameManager

Responsible for global game state.

Handles:

* Score tracking
* Target/base health
* Lose condition

---

### EnemyManager

Tracks all active enemies in the scene.

Responsibilities:

* Register enemies when they spawn
* Remove enemies when they die
* Provide towers with a list of enemies

This avoids expensive scene queries such as `FindObjectsOfType`.

---

### EnemyController

Controls enemy behavior.

Responsibilities:

* Movement toward the target
* Taking damage
* Triggering hit and death effects
* Informing GameManager when destroyed

Enemy behavior reads configuration values from `EnemyStats`.

---

### EnemyStats (ScriptableObject)

Stores configurable enemy data:

* Max Health
* Movement Speed
* Damage To Target
* Score Value

Using ScriptableObjects allows designers to tweak enemy balance without modifying gameplay code.

---

### TowerBase

Abstract base class for towers.

Responsibilities:

* Detect enemies within range
* Manage firing timing
* Provide shared tower functionality

Specific tower behaviors are implemented in derived classes.

---

### AOETower

Targets one enemy and fires a projectile that deals **area-of-effect damage** to nearby enemies.

---

### MultiTargetTower

Targets multiple enemies simultaneously and fires projectiles at each target.

---

### Projectile

Responsible for:

* Moving toward a target
* Applying damage on impact
* Applying optional area damage via configurable radius

---

## Data vs Logic Separation

Gameplay configuration values are stored in **ScriptableObjects** such as `EnemyStats`.

Advantages of this approach:

* Designers can tweak gameplay values without changing code
* Reduces merge conflicts between designers and programmers
* Allows gameplay logic to remain reusable and clean

Game systems read these values but do not hardcode gameplay configuration.

---

## Trade-offs (Time Constraints)

Given the **3–4 hour implementation constraint**, several simplifications were intentionally made:

* Enemy movement uses direct movement toward the base rather than a full pathfinding system.
* Towers are pre-placed in the scene rather than implementing a tower placement system.
* Object pooling for enemies and projectiles was not implemented.
* Enemy targeting iterates through enemies tracked by `EnemyManager` rather than using spatial partitioning.
* Visual effects are intentionally minimal.

These decisions were made to **prioritize architectural clarity over additional gameplay systems**.

---

## What I Would Do With More Time

If additional development time were available, the following improvements would be implemented.

### Performance

Introduce **object pooling** for enemies and projectiles to reduce runtime allocations.

### Gameplay Systems

Implement a **wave-based spawning system** with configurable wave data.

### Tower System

Create modular tower behaviors allowing designers to mix abilities through composition.

### Enemy AI

Replace direct movement with waypoint-based paths or navigation systems.

### Architecture

Introduce **event-driven messaging** between systems to reduce coupling.

---

## Scene to Run

Open the following scene in Unity and press **Play**:

Assets/Scenes/MainScene.unity

---

## Controls

Left Mouse Click → Damage enemies

---

## Total Time Spent

Approximately **3–4 hours**

---

## Notes

This prototype focuses on demonstrating **clean architecture and extensibility** rather than visual polish. The goal is to show how the project could scale if expanded by a team.
