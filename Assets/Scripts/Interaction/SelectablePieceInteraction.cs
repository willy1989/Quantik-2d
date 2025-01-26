using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectablePieceInteraction : MonoBehaviour, IPointerClickHandler
{
    public Action<SelectablePieceInteraction> OnClicked;

    public Action OnPointerUpEvent;

    public Action OnClickedNoArgument;

    public GridElement AssociatedGridElement { get; private set; }

    public Action OnPiecePlaced;

    bool piecePlaced = false;

    public Action OnSetup;

    public void Setup(GridElement associatedGridElement)
    {
        AssociatedGridElement = associatedGridElement;

        OnSetup?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (piecePlaced == true)
            return;

        OnClicked?.Invoke(this);
        OnClickedNoArgument?.Invoke();
    }

    public void UsePiece()
    {
        piecePlaced = true;
        OnPiecePlaced?.Invoke();
    }
}
