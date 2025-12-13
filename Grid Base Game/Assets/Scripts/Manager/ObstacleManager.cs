using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GridData obstacleData;
    [SerializeField] private GameObject spherePrefab;

    private bool[,] ObstacleTile;

    private float z_offset = 0.3f;

    private void Start()
    {
        ObstacleTile = new bool[obstacleData.Width, obstacleData.Height];

        for (int i = 0; i < obstacleData.Width; i++)
        {
            for (int j = 0; j < obstacleData.Height; j++)
            {
                int index = j * obstacleData.Width + i;
                bool isEmptySpace = obstacleData.Cell[index];

                ObstacleTile[i, j] = isEmptySpace;

                if (isEmptySpace)
                {
                    Vector3 position = new Vector3(j, z_offset, i);
                    GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
                    
                    sphere.transform.position = position;
                    sphere.name = $"Sphere[{j}][{i}]";

                    Renderer renderer = sphere.GetComponentInChildren<Renderer>();
                    renderer.material.color = Color.red;
                }
            }
        }
    }

    public bool[,] GetObstacelList()
    {
        return ObstacleTile;
    }
}
