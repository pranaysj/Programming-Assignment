using UnityEngine;
using UnityEngine.WSA;

public class MouseTileDetector : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private GameObject currentTile;

    void Update()
    {
        DetectTile();
    }

    private void DetectTile()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;

            //Get the Child Text tranform
            Transform transformTXT = hitObject.transform.Find("Pos_Text");

            if (transformTXT != null)
            {
                //Get the Tile tex gameObject from the text transform
                GameObject tileTXT = transformTXT.gameObject;

                //Check if the current tile is different from the detected tile
                if (currentTile != tileTXT)
                {
                    //Deactivate the previous tile text if exists
                    if (currentTile != null)
                    {
                        currentTile.SetActive(false);
                    }

                    //Activate the new tile text
                    tileTXT.SetActive(true);
                    currentTile = tileTXT;
                    
                }
                // Exit the method after processing the hit
                return;
            }

        }
        
        if (currentTile != null)
        {
            currentTile.SetActive(false);
            currentTile = null;
        }


    }
}
