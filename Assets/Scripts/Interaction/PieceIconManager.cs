using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIconManager : MonoBehaviour
{
    [SerializeField] private PieceIcon[] pieceIcons;

    public void Setup(Player player)
    {
        for (int i = 0; i < player.StartingGridElements.Count; i++)
        {
            pieceIcons[i].Setup(player.StartingGridElements[i]);
        }
    }
}
