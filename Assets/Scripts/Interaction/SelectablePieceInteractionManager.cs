using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectablePieceInteractionManager : MonoBehaviour
{
    [SerializeField] private SelectablePieceInteraction[] selectablePieces;

    public SelectablePieceInteraction[] SelectablePieces => selectablePieces;

    public SelectablePieceInteraction CurrentPieceInteraction { get; private set; }

    public void Setup(Player player)
    {
        for (int i = 0; i < player.StartingGridElements.Count; i++)
        {
            selectablePieces[i].Setup(player.StartingGridElements[i]);
            selectablePieces[i].OnPiecePickedUp += SetCurrentGridElement;
        }
    }

    public void SetCurrentPieceInteractionUnselectable()
    {
        CurrentPieceInteraction.SetIsSelectable(false);
        CurrentPieceInteraction = null;
    }

    public void ResetCurrentPieceInteraction()
    {
        CurrentPieceInteraction.SetIsSelectable(true);
        CurrentPieceInteraction = null;
    }

    private void SetCurrentGridElement(SelectablePieceInteraction pieceInteraction)
    {
        CurrentPieceInteraction = pieceInteraction;
    }
}
