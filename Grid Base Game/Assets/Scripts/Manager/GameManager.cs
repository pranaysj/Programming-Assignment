using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public ObstacleManager obstacleManager;
    public PlayerManager playerManager;

    void Start()
    {
        gridManager.GenerateGrid();
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(5.0f);
        obstacleManager.enabled = true;
        playerManager.enabled = true;
    }
}
