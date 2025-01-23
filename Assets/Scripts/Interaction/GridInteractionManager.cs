using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInteractionManager : MonoBehaviour
{
    [SerializeField] private PositionTile[] positionTiles;

    [SerializeField] private SelectablePiecesManager selectablePiecesManager;

    private SelectablePiece currentPiece;

    private Grid grid;

    private void Awake()
    {
        foreach (SelectablePiece piece in selectablePiecesManager.SelectablePieces)
        {
            piece.OnClicked += SetCurrentPiece;
        }
    }

    private void Update()
    {
        if (currentPiece == null)
            return;

        if (Input.GetMouseButtonDown(0) == false)
            return;
        
        PositionTile positionTile = GetPositionTileFromMousePosition();

        if(positionTile == null) 
            return;

        Vector2Int gridCoordinates = positionTile.GridCoordinate;

        grid.AddElement(currentPiece.AssociatedGridElement, gridCoordinates.x, gridCoordinates.y);

        currentPiece.UsePiece(onOff:true);

        currentPiece = null;
    }

    public void Setup(Grid grid)
    {
        this.grid = grid;

        int i = 0;

        for(int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                positionTiles[i].Setup(new Vector2Int (x, y));
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

    private void SetCurrentPiece(SelectablePiece targetPiece)
    {
        currentPiece = targetPiece;
        Debug.Log(currentPiece.name);
    }
}
