using System.Collections;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int gridWidth = 10;
    private int gridHeight = 10;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject[,] grid;

    public void GenerateGrid()
    {
        //Set the grid size
        grid = new GameObject[gridWidth, gridHeight];

        StartCoroutine(GenerateGridRoutine());
    }

    private IEnumerator GenerateGridRoutine()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(x, 0, y);
                // Instantiate tile prefab 
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);


                // Name the tile
                tile.name = "Tile[" + x + "][" + y + "]";

                ToggleColor(tile);

                //Add the tile to the grid array
                grid[x, y] = tile;

                //Initialize the tile
                TileInfo tileInfo = tile.GetComponentInChildren<TileInfo>();
                tileInfo.Initialize(x, y);

                //Yield to avoid freezing
                yield return new WaitForSeconds(0.05f); ;
            }
        }
    }

    //Toggle the color of tiles
    private void ToggleColor(GameObject tile)
    {
        Renderer renderer = tile.GetComponentInChildren<Renderer>();
        float positionSum = tile.transform.position.x + tile.transform.position.z;

        renderer.material.color = positionSum % 2 == 0 ? Color.white : Color.grey;

    }
}
