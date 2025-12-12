using TMPro;
using UnityEngine;

public class TileInfo :MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private TileUIText tileUIText;

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }


    public void Initialize(int x, int y)
    {
        this.x = x;
        this.y = y;

        // Set the text UI for the tile
        tileUIText.SetText(this);
    }


}
