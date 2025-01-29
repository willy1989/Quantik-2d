using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIconContainer : MonoBehaviour
{
    [SerializeField] private PieceIcon pieceIcon;

    public PieceIcon GetPieceIcon()
    {
        if (pieceIcon.IsPlaced == true)
            return null;

        return pieceIcon; 
    }
}
