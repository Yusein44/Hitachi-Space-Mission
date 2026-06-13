# Space Mission 2026 - Shortest Path Navigator

## Project Overview
This is a C# (.NET Core) Console Application developed as a technical assignment. The goal of the project is to navigate multiple astronauts through a 2D cosmic grid, avoiding obstacles (asteroids), and finding the shortest possible path to the Space Station.

## Architecture & Design
The application is built with strong **Object-Oriented Programming (OOP)** principles in mind, moving away from a single-file approach to a modular and maintainable structure.

*   **`Astronaut.cs`**: Represents the entity of an astronaut, storing their ID, starting coordinates, personal solved map, and mission status.
*   **`Position.cs`**: A utility class handling grid coordinates (Row, Column) for robust movement tracking.
*   **`PathFinder.cs`**: The core navigation engine. It implements the **Breadth-First Search (BFS)** algorithm to guarantee the shortest possible path in an unweighted grid while strictly avoiding 'X' (Asteroid) obstacles.
*   **`Program.cs`**: The entry point that handles input parsing, map initialization, and UI output rendering.

## Key Features
*   **Multi-Agent Support:** Capable of tracking and calculating paths for multiple astronauts simultaneously.
*   **Optimal Pathfinding:** Utilizes BFS to ensure the mathematically shortest route to the station.
*   **Visual Output:** Generates a custom grid for each successfully navigated astronaut, mapping their specific route with `*` symbols.
*   **Result Sorting:** Automatically sorts output data, displaying lost astronauts first, followed by saved astronauts ordered by shortest path length.

## How to Run
1. Clone the repository to your local machine.
2. Open the solution in **Visual Studio 2022**.
3. Run the project (`F5`).
4. Enter the grid dimensions (Rows, then Columns).
5. Paste the map layout (space-separated).
