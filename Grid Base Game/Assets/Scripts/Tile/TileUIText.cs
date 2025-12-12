using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TileUIText : MonoBehaviour
{
    [SerializeField] private TMP_Text positoinTXT;

    private void Start()
    {
        positoinTXT = GetComponentInParent<TMP_Text>();
    }

    public void SetText(TileInfo tileInfo)
    {
        positoinTXT.text = $"({tileInfo.X}, {tileInfo.Y})";
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
