# Grid-Based Pathfinding System (Unity)

A Unity project demonstrating **grid generation**, **editor tooling**, and **custom grid-based pathfinding** without using Unity NavMesh.

---

## Video
https://github.com/user-attachments/assets/66046dc7-7ec3-44cc-a7cc-367406e80b7d

---

## 📌 Features

- 10×10 grid generation using Unity Cubes
- Tile metadata stored per grid cell
- Mouse raycast tile detection with UI feedback
- Custom Unity Editor tool for obstacle placement
- Obstacle data stored in ScriptableObjects
- Runtime obstacle visualization
- Grid-based pathfinding (BFS)
- Smooth tile-to-tile player movement
- Input locking during movement

---

## 📂 Assignments Breakdown

### Assignment 1 – Grid Block Generation
- Generates a **10×10 grid** of cube GameObjects
- Each tile contains:
  - Grid X, Y position
  - Tile metadata script
- Mouse raycast detects hovered tile
- Tile grid position is displayed on UI

---

### Assignment 2 – Obstacles System
- Custom **Unity Editor Window** with 10×10 toggle grid
- Toggle state represents blocked tiles
- Obstacle data saved in a **ScriptableObject**
- `ObstacleManager` reads data and spawns **red sphere obstacles**

---

### Assignment 3 – Pathfinding
- Player unit spawns on the grid
- Click to move player to selected tile
- Player cannot traverse blocked tiles
- Uses **grid-based BFS pathfinding**
- Smooth movement using coroutines
- Input disabled while player is moving

---

## 🧠 Pathfinding Approach

- Algorithm: **Breadth-First Search (BFS)**
- Movement: 4-directional (Up, Down, Left, Right)
- Blocked tiles are excluded
- Path reconstructed using parent mapping

---



