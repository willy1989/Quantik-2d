using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterInteractionManager : MonoBehaviour
{
    [SerializeField] private PieceIconManager whitePlayerPieceIconManager;
    [SerializeField] private PieceIconManager blackPlayerPieceIconManager;

    [SerializeField] private PieceInteractionRaycaster pieceInteractionRaycaster;

    [SerializeField] private PositionTile[] positionTiles;

    [SerializeField] private PieceIconSwitcher[] pieceIconSwitchers;

    private PieceIcon currentPieceIcon;

    private PieceIconManager currentPieceIconManager;

    [SerializeField] Button switchPlayerButton_DEBUG;

    public Action<GridElement, Vector2Int> OnPlaceGridElement;

    private void Update()
    {
        InterractWithPieceIconContainer();
        InterractWithPositionTile();
    }

    public void Setup(Grid grid, Player whitePlayer, Player blackPlayer)
    {
        whitePlayerPieceIconManager.Setup(grid, whitePlayer);
        blackPlayerPieceIconManager.Setup(grid, blackPlayer);

        int i = 0;

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                positionTiles[i].Setup(new Vector2Int(x, y));
                i++;
            }
        }

        foreach (PieceIconSwitcher switcher in pieceIconSwitchers)
        {
            switcher.SwitchPieceIcon(GridElement.GridElementColor.White);
        }
    }

    public void SwitchPlayer(Player player)
    {
        if(player.ElementColor == GridElement.GridElementColor.Black)
            currentPieceIconManager = blackPlayerPieceIconManager;

        else if(player.ElementColor == GridElement.GridElementColor.White)
            currentPieceIconManager = whitePlayerPieceIconManager;

        else
        {
            throw new ArgumentException("A player should be either black or white.");
        }

        currentPieceIcon = null;

        foreach (PieceIconSwitcher switcher in pieceIconSwitchers)
        {
            switcher.SwitchPieceIcon(player.ElementColor);
        }
    }

    private void InterractWithPieceIconContainer()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        TryGetPieceIconFromIconContainer(out PieceIcon pieceIcon);

        if (pieceIcon != null)
            PickupPieceIcon(pieceIcon);
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

    private void PickupPieceIcon(PieceIcon pieceIcon)
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
        bool pieceWasPlaced = currentPieceIconManager.TryPlacePiece(currentPieceIcon.GetAssociatedGridElement(), gridCoordinates);

        if (pieceWasPlaced == true)
        {
            currentPieceIcon.Place();

            OnPlaceGridElement?.Invoke(currentPieceIcon.GetAssociatedGridElement(), gridCoordinates);
            currentPieceIcon = null;
        }

        else
        {
            DropIcon();
        }
    }
}
