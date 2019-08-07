using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject target;
    public GameObject selector;
    public TerrainCollider board; 

    private void Update()
    {
        updateSelectedTile();
    }

    private void LateUpdate()
    {
        updateSelector();
    }

    private void updateSelector()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        try
        {
            if (board.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                Vector3 selectorTransform = hitInfo.point;                      // New vector to snap selector to grid
                selectorTransform.x = Mathf.Round(hitInfo.point.x);
                selectorTransform.z = Mathf.Round(hitInfo.point.z);
                selectorTransform.y = 0.1f;                                     // Hover over Board
                selector.transform.position = selectorTransform;
            }
        }
        catch
        {
            Debug.Log("Unable to update location for Tile Selector");
        }
    }

    private void updateSelectedTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        try
        {
            if (board.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                Vector3 targetTransform = hitInfo.point;
                targetTransform.y = 0.3f;
                target.transform.position = targetTransform;                    // Hover over Selector
            }
        }
        catch
        {
            Debug.Log("Unable to update location for Selected Tile");
        }
    }
}
