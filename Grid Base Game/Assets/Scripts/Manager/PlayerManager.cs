using NUnit.Framework;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private GameObject player;
    PlayerController controller;

    private Vector2Int startPosition;
    private Vector2Int endPosition;
    private bool[,] blockedPosition;

    public List<Vector2Int> path;


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
        Vector3 startPosition = new Vector3(2, 0.5f, 5);
        player = Instantiate(playerPrefab, startPosition, Quaternion.identity);
        player.name = "Player";
    }

    private void GetPlayerPosition()
    {
        controller = player.GetComponent<PlayerController>();
        startPosition = controller.GetCurrentPosition();
    }

    private void GetEndPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            TileInfo tileInfo = hitObject.GetComponent<TileInfo>();
            if (tileInfo != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    endPosition = new Vector2Int(tileInfo.X, tileInfo.Y);

                    GetPlayerPosition();
                    GetObstacelTile();

                    var path = GridBasePathFInder.FindPath(startPosition, endPosition, blockedPosition);
                    Debug.Log("Path found with " + path.Count + " tiles.");
                    controller.Initialize(path);

                }
            }
        }
    }

    public void GetObstacelTile()
    {
        var script = GetComponent<ObstacleManager>();
        blockedPosition = script.GetObstacelList();
    }
}
