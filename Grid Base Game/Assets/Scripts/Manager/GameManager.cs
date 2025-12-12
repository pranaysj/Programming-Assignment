using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;

    void Start()
    {
        gridManager.GenerateGrid();
    }

}
