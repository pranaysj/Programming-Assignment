using UnityEngine;
using System.Collections.Generic;

public static class GridBasePathFInder
{
    public static List<Vector2Int> FindPath(Vector2Int start, Vector2Int end, bool[,] blocked)
    {
        int width = blocked.GetLength(0);
        int height = blocked.GetLength(1);

        List<Vector2Int> path = new List<Vector2Int>();

        // Validate tiles
        if (!IsValidTile(start, width, height) || !IsValidTile(end, width, height))
            return path;

        if (blocked[start.x, start.y] || blocked[end.x, end.y])
            return path;

        // Start == End → trivial path
        if (start == end)
        {
            path.Add(start);
            return path;
        }

        bool[,] visited = new bool[width, height];
        Dictionary<Vector2Int, Vector2Int> parent = new();
        Queue<Vector2Int> queue = new();

        Vector2Int[] directions = {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1)
        };

        visited[start.x, start.y] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();

            foreach (var dir in directions)
            {
                Vector2Int next = current + dir;

                if (!IsValidTile(next, width, height)) continue;
                if (blocked[next.x, next.y]) continue;
                if (visited[next.x, next.y]) continue;

                visited[next.x, next.y] = true;
                parent[next] = current;

                // Reached endpoint → reconstruct path
                if (next == end)
                {
                    Vector2Int node = end;

                    while (node != start)
                    {
                        path.Add(node);
                        node = parent[node];
                    }
                    path.Add(start);
                    path.Reverse();
                    return path;
                }

                queue.Enqueue(next);
            }
        }

        return path; // Empty list if no valid path exists
    }

    private static bool IsValidTile(Vector2Int pos, int width, int height)
    {
        return pos.x >= 0 && pos.x < width && pos.y >= 0 && pos.y < height;
    }
}
