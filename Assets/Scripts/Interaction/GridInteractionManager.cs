using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInteractionManager : MonoBehaviour
{
    [SerializeField] private PositionTile[] positionTiles;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PositionTile positionTile = GetPositionTileFromMousePosition();

            if (positionTile != null)
            {
                Debug.Log(positionTile.GridCoordinate);
            }
        }
    }

    public void SetPositionTilesCoordinates(Grid grid)
    {
        int i = 0;

        for(int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                positionTiles[i].Setup(new Vector2 (x, y));
                i++;
            }
        }
    }

    private PositionTile GetPositionTileFromMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject clickedObject = hit.collider.gameObject;

            PositionTile positionTile = clickedObject.GetComponent<PositionTile>();

            if (positionTile != null)
            {
                return positionTile;
            }
        }

        return null;
    }
}
