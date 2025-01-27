using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInteractionManager : MonoBehaviour
{
    [SerializeField] private SelectablePieceInteractionManager selectablePieceInteractionManager;

    [SerializeField] private GridInteractionManager gridInteractionManager;

    private void Awake()
    {
        gridInteractionManager.OnPiecePlaced += selectablePieceInteractionManager.SetCurrentPieceInteractionUnselectable;

        gridInteractionManager.OnPieceDropped += selectablePieceInteractionManager.ResetCurrentPieceInteraction;
    }


    private void Update()
    {
        // Select phase
        if(selectablePieceInteractionManager.CurrentPieceInteraction == null)
        {
            gridInteractionManager.Toggle(false);
        }

        // Place phase
        else
        {
            gridInteractionManager.Toggle(true);
            gridInteractionManager.TryPlacePiece(selectablePieceInteractionManager.CurrentPieceInteraction.AssociatedGridElement);
        }
    }
}
