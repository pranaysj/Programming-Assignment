using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private GameObject player;
    private PlayerController controller;

    private Vector2Int startPosition;
    private Vector2Int endPosition;
    private bool[,] blockedPosition;

    private void Start()
    {
        CreatePlayer();
    }

    private void Update()
    {
        GetEndPosition();
    }

    private void CreatePlayer()
    {
        Vector3 startWorldPos = new Vector3(2, 0.5f, 5);
        player = Instantiate(playerPrefab, startWorldPos, Quaternion.identity);
        player.name = "Player";

        controller = player.GetComponent<PlayerController>();

        //Change the color of the player
        Renderer renderer = player.GetComponentInChildren<Renderer>();
        Color newColor = new Color32(54, 143, 197, 255);
        renderer.material.color = newColor;

        // Set the start position
        startPosition = new Vector2Int((int)startWorldPos.x, (int)startWorldPos.z);

        // Initialize the player controller with the start position
        controller.Initialize(new List<Vector2Int> { startPosition });
    }

    private void GetEndPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Perform the raycast
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            TileInfo tileInfo = hitInfo.collider.GetComponent<TileInfo>();

            // Check if we hit a tile
            if (tileInfo != null && Input.GetMouseButtonDown(0))
            {
                endPosition = new Vector2Int(tileInfo.X, tileInfo.Y);

                UpdateStartPosition();
                GetObstacleTiles();

                // Find path
                List<Vector2Int> path = GridBasePathFInder.FindPath(startPosition, endPosition, blockedPosition);

                // Move player along the path
                if (path.Count > 0)
                {
                    controller.Initialize(path);
                    controller.MoveAlongPath();
                }
            }
        }
    }

    private void UpdateStartPosition()
    {
        Vector3 pos = player.transform.position;
        startPosition = new Vector2Int((int)pos.x, (int)pos.z);
    }

    private void GetObstacleTiles()
    {
        var script = GetComponent<ObstacleManager>();
        blockedPosition = script.GetObstacelList();
    }
}
