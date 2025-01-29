using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInteractionManager : MonoBehaviour
{
    [SerializeField] private GridInteractionManager gridInteractionManager;

    [SerializeField] private PieceInteractionRaycaster pieceInteractionRaycaster;

    private PieceIcon currentPieceIcon;


    private void Update()
    {
        InterractWithPieceIconContainer();
        InterractWithPositionTile();
    }

    private void InterractWithPieceIconContainer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PieceIconContainer pieceIconContainer = pieceInteractionRaycaster.GetPieceIconContainer();

            if (pieceIconContainer != null)
            {
                PieceIcon pieceIcon = pieceIconContainer.GetPieceIcon();

                if(pieceIcon != null)
                {
                    currentPieceIcon = pieceIconContainer.GetPieceIcon();
                    currentPieceIcon.Drop(false);
                    currentPieceIcon.PickUp(true);
                }
            }
        }
    }

    private void InterractWithPositionTile()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PositionTile positionTile = pieceInteractionRaycaster.GetPositionTileFromMousePosition();

            if (positionTile == null)
            {
                if(currentPieceIcon != null)
                {
                    currentPieceIcon.PickUp(false);
                    currentPieceIcon.Drop(true);
                    currentPieceIcon = null;
                }
            }

            else
            {
                if(currentPieceIcon != null)
                {
                    bool pieceWasPlaced = gridInteractionManager.TryPlacePiece(currentPieceIcon.GetAssociatedGridElement(), positionTile);

                    if(pieceWasPlaced == true)
                    {
                        currentPieceIcon.Drop(false);
                        currentPieceIcon.PickUp(false);
                        currentPieceIcon.Place(true);

                        currentPieceIcon = null;
                    }
                }
            }
        }
    }
}
