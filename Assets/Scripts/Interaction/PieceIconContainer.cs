using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIconContainer : MonoBehaviour
{
    [SerializeField] private PieceIcon pieceIcon;

    public void SetPieceIcon(PieceIcon pieceIcon)
    {
        this.pieceIcon = pieceIcon;
    }
    public PieceIcon GetPieceIcon()
    {
        if (pieceIcon.IsPlaced == true)
            return null;

        return pieceIcon; 
    }
}
