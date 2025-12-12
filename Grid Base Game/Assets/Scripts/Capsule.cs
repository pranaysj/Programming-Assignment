using UnityEngine;

public class Capsule : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        TileInfo tileInfo = collision.gameObject.GetComponent<TileInfo>();
        if (tileInfo != null)
        {
            Debug.Log($"Player collided with tile at position: ({tileInfo.X}, {tileInfo.Y})");
        }
    }
}
