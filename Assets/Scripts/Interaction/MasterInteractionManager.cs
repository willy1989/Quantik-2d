using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInteractionManager : MonoBehaviour
{
    [SerializeField] private PieceIconManager whitePlayerPieceIconManager;
    [SerializeField] private PieceIconManager blackPlayerPieceIconManager;

    [SerializeField] private PieceInteractionRaycaster pieceInteractionRaycaster;

    [SerializeField] private PositionTile[] positionTiles;

    private PieceIcon currentPieceIcon;

    private void Update()
    {
        InterractWithPieceIconContainer();
        InterractWithPositionTile();
    }

    public void Setup(Grid grid, Player whitePlayer)
    {
        whitePlayerPieceIconManager.Setup(grid,whitePlayer);

        int i = 0;

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                positionTiles[i].Setup(new Vector2Int(x, y));
                i++;
            }
        }
    }

    private void InterractWithPieceIconContainer()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        TryGetPieceIconFromIconContainer(out PieceIcon pieceIcon);

        if (pieceIcon != null)
            PlacePieceIcon(pieceIcon);
    }

    private bool TryGetPieceIconFromIconContainer(out PieceIcon pieceIcon)
    {
        pieceIcon = null;

        PieceIconContainer pieceIconContainer = pieceInteractionRaycaster.GetPieceIconContainer();
        if (pieceIconContainer == null)
            return false;

        pieceIcon = pieceIconContainer.GetPieceIcon();
        return pieceIcon != null;
    }

    private void PlacePieceIcon(PieceIcon pieceIcon)
    {
        currentPieceIcon = pieceIcon;
        currentPieceIcon.PickUp();
    }

    private void InterractWithPositionTile()
    {
        if (Input.GetMouseButtonUp(0) == false)
            return;

        if (currentPieceIcon == null)
            return;

        PositionTile positionTile = pieceInteractionRaycaster.GetPositionTileFromMousePosition();

        if (positionTile == null)
        {
            DropIcon();
        }

        else
        {
            TryPlaceIcon(positionTile.GridCoordinate);
        }
    }

    private void DropIcon()
    {
        currentPieceIcon.Drop();
        currentPieceIcon = null;
    }

    private void TryPlaceIcon(Vector2Int gridCoordinates)
    {
        bool pieceWasPlaced = whitePlayerPieceIconManager.TryPlacePiece(currentPieceIcon.GetAssociatedGridElement(), gridCoordinates);

        if (pieceWasPlaced == true)
        {
            currentPieceIcon.Place();
            currentPieceIcon = null;
        }
    }
}
