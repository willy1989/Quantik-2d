using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIconUI : MonoBehaviour
{
    [SerializeField] private PieceIconSwitcher pieceIconSwitcher;

    private PieceIconStaticGraphics pieceIconStaticGraphics;
    private PieceIconFollowGraphics pieceIconFollowGraphics;
    private PieceIconContainer pieceIconContainer;

    private void Awake()
    {
        pieceIconStaticGraphics = GetComponent<PieceIconStaticGraphics>();
        pieceIconFollowGraphics = GetComponent<PieceIconFollowGraphics>();
        pieceIconContainer = GetComponent<PieceIconContainer>();

        pieceIconSwitcher.OnSwitchPieceIcon += SetPieceIcon;
    }

    private void SetPieceIcon(PieceIcon pieceIcon)
    {
        pieceIconStaticGraphics.SetPieceIcon(pieceIcon);
        pieceIconFollowGraphics.SetPieceIcon(pieceIcon);
        pieceIconContainer.SetPieceIcon(pieceIcon);
    }
    
}
