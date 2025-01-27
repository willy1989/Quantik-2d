using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInteractionManager : MonoBehaviour
{
    [SerializeField] private PositionTile[] positionTiles;

    private Grid grid;

    private Player player;

    private bool canRun = false;

    public Action OnPiecePlaced;

    public Action OnPieceDropped;

    public void Toggle(bool onOff)
    {
        canRun = onOff;
    }

    public void TryPlacePiece(GridElement gridElement)
    {
        if (canRun == false)
            return;

        if (Input.GetMouseButtonUp(0) == false)
            return;
        
        PositionTile positionTile = GetPositionTileFromMousePosition();

        if (positionTile == null)
        {
            OnPieceDropped?.Invoke();
            return;
        }

        Vector2Int gridCoordinates = positionTile.GridCoordinate;

        if(grid.IsCellEmpty(gridCoordinates.x, gridCoordinates.y) == false)
        {
            OnPieceDropped?.Invoke();
            return;
        }

        player.PlayPiece(gridElement, gridCoordinates.x, gridCoordinates.y);

        OnPiecePlaced?.Invoke();
    }

    public void Setup(Grid grid, Player player)
    {
        this.grid = grid;
        this.player = player;

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
}
