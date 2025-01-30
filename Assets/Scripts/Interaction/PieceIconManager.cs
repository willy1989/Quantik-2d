using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIconManager : MonoBehaviour
{
    [SerializeField] private PieceIcon[] pieceIcons;

    private Grid grid;

    private Player player;

    public bool TryPlacePiece(GridElement gridElement, Vector2Int gridCoordinates)
    {
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

        for (int i = 0; i < player.StartingGridElements.Count; i++)
        {
            pieceIcons[i].Setup(player.StartingGridElements[i]);
        }
    }
}
