using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2Int currentPos;
    private Vector2 targetPos;

    public List<Vector2Int> path;

    public void Initialize(List<Vector2Int> path)
    {
        foreach (var tile in path)
        {
            Debug.Log("Path Tile: " + tile);
        }
        this.path = path;
        currentPos = path[0];   // Start tile
        transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
    }

    public void MoveAlongPath()
    {
        StartCoroutine(FollowPathRoutine());
    }

    private IEnumerator FollowPathRoutine()
    {
        foreach (var nextTile in path)
        {
            yield return StartCoroutine(MoveToNextTile(nextTile));
        }
    }

    private IEnumerator MoveToNextTile(Vector2Int nextTilePos)
    {
        targetPos = nextTilePos;

        while ((Vector2)transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPos,
                Time.deltaTime * 2f
            );

            yield return null; // Wait until next frame
        }

        // Update grid position when reached
        currentPos = nextTilePos;
    }

    public Vector2Int GetCurrentPosition()
    {
        return currentPos;
    }
}
