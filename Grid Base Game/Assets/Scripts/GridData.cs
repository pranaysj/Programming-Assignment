using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridData_10x10", menuName = "Grid/GridData 10x10")]
public class GridData : ScriptableObject
{
    // flattened 2D array to 1D array (y * width + x)
    [SerializeField] int width = 10;
    [SerializeField] int height = 10;
    [SerializeField] List<bool> cells = new List<bool>();
    public int Width => width;
    public int Height => height;
    public List<bool> Cell => cells;

    private void OnEnable()
    {
        if (cells == null || cells.Count != width * height)
        {
            cells = new List<bool>(new bool[width * height]);
        }
    }

    public void Set(int x, int y, bool val)
    {
        Validate();
        cells[y * width + x] = val;
    }


    void Validate()
    {
        var multiple = width * height;

        if (cells == null || cells.Count != multiple)
        {
            cells = new List<bool>(new bool[multiple]);
        }
    }
}
