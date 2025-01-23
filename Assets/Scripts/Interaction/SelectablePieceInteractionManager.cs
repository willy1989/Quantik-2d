using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectablePieceInteractionManager : MonoBehaviour
{
    [SerializeField] private SelectablePieceInteraction[] selectablePieces;

    public SelectablePieceInteraction[] SelectablePieces => selectablePieces;

    public void SetupSelectablePieces(Player player)
    {
        for (int i = 0; i < player.StartingShapes.Count; i++)
        {
            selectablePieces[i].Setup(new GridElement(shape: player.StartingShapes[i], player.ElementColor));
        }
    }
}
