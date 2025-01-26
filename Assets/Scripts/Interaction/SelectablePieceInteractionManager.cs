using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectablePieceInteractionManager : MonoBehaviour
{
    [SerializeField] private SelectablePieceInteraction[] selectablePieces;

    public SelectablePieceInteraction[] SelectablePieces => selectablePieces;

    public void SetupSelectablePieces(Player player)
    {
        for (int i = 0; i < player.StartingGridElements.Count; i++)
        {
            selectablePieces[i].Setup(player.StartingGridElements[i]);
        }
    }
}
