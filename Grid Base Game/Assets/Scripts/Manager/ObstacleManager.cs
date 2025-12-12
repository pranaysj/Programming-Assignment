using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GridData obstacleData;
    [SerializeField] private GameObject spherePrefab;

    private float z_offset = 0.3f;

    private void Start()
    {
        for (int i = 0; i < obstacleData.Width; i++)
        {
            for (int j = 0; j < obstacleData.Height; j++)
            {
                int index = j * obstacleData.Width + i;
                bool isEmptySpace = obstacleData.Cell[index];

                if(isEmptySpace)
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
}
