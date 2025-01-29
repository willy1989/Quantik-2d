using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInteractionManager : MonoBehaviour
{
    [SerializeField] private PositionTile[] positionTiles;

    private Grid grid;

    private Player player;

    public bool TryPlacePiece(GridElement gridElement, PositionTile positionTile)
    {
        Vector2Int gridCoordinates = positionTile.GridCoordinate;

        if(grid.IsCellEmpty(gridCoordinates.x, gridCoordinates.y) == false)
        {
            return false;
        }

        return player.TryPlayPiece(gridElement, gridCoordinates.x, gridCoordinates.y);

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
}
