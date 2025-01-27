using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectablePieceInteraction : MonoBehaviour, IPointerDownHandler
{
    public GridElement AssociatedGridElement { get; private set; }

    public Action OnSetup;

    public Action<SelectablePieceInteraction> OnPiecePickedUp;

    public Action OnIsSelectableOn;

    public Action OnIsSelectableOff;

    bool isSelectable = true;

    public void Setup(GridElement associatedGridElement)
    {
        AssociatedGridElement = associatedGridElement;

        OnSetup?.Invoke();
    }

    public void SetIsSelectable(bool pieceIsSelectable)
    {
        this.isSelectable = pieceIsSelectable;
        if(isSelectable == true)
        {
            OnIsSelectableOn?.Invoke();
        }

        else
        {
            OnIsSelectableOff?.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(isSelectable == false)
            return;

        OnPiecePickedUp?.Invoke(this);
    }
}
