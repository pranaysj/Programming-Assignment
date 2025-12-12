using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2Int currentPos;
    private Vector3 targetPos;

    private List<Vector2Int> path;

    // Initialize player with the path
    public void Initialize(List<Vector2Int> newPath)
    {
        if (newPath == null || newPath.Count == 0)
            return;

        path = new List<Vector2Int>(newPath);

        // First tile is the start tile
        currentPos = path[0];

        // Set world position from grid coordinates
        transform.position = GridToWorld(currentPos);

        // Remove the first tile so movement begins from next tile
        if (path.Count > 1)
            path.RemoveAt(0);
    }

    public void MoveAlongPath()
    {
        if (path == null || path.Count == 0)
            return;

        StartCoroutine(FollowPathRoutine());
    }

    private IEnumerator FollowPathRoutine()
    {
        foreach (var nextTile in path)
        {
            yield return MoveToNextTile(nextTile);
        }
    }

    private IEnumerator MoveToNextTile(Vector2Int nextTilePos)
    {
        targetPos = GridToWorld(nextTilePos);

        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                Time.deltaTime * 3f // movement speed
            );
            yield return null;
        }

        currentPos = nextTilePos;
    }

    // Convert grid X,Y → world X,Z
    private Vector3 GridToWorld(Vector2Int grid)
    {
        return new Vector3(grid.x, 0.5f, grid.y);
    }

    public Vector2Int GetCurrentPosition()
    {
        return currentPos;
    }
}
