using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIconSwitcher : MonoBehaviour
{
    [SerializeField] private PieceIcon whitePieceIcon;
    [SerializeField] private PieceIcon blackPieceIcon;

    public Action<PieceIcon> OnSwitchPieceIcon;

    public void SwitchPieceIcon(GridElement.GridElementColor pieceColor)
    {
        PieceIcon pieceIcon = null;

        if(pieceColor == GridElement.GridElementColor.White)
            pieceIcon = whitePieceIcon;
        else
            pieceIcon = blackPieceIcon;

        pieceIcon.ResetEvents();

        OnSwitchPieceIcon?.Invoke(pieceIcon);
    }
}
