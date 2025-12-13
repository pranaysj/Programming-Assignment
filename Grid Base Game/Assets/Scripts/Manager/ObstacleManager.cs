using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GridData obstacleData;
    [SerializeField] private GameObject spherePrefab;

    private bool[,] ObstacleTile;

    private float z_offset = 0.3f;

    private void Start()
    {
        //Initialize the obstacle tiles based on the obstacle data
        ObstacleTile = new bool[obstacleData.Width, obstacleData.Height];

        for (int i = 0; i < obstacleData.Width; i++)
        {
            for (int j = 0; j < obstacleData.Height; j++)
            {
                //Calculate the index in the one-dimensional Cell array
                int index = j * obstacleData.Width + i;
                bool isEmptySpace = obstacleData.Cell[index];

                //Store the obstacle information in the 2D array
                ObstacleTile[i, j] = isEmptySpace;

                //If it's an obstacle, instantiate a sphere at that position
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
