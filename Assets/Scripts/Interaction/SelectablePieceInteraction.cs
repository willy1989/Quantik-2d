using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectablePieceInteraction : MonoBehaviour, IPointerClickHandler
{
    public Action<SelectablePieceInteraction> OnClicked;

    public GridElement AssociatedGridElement { get; private set; }

    public Action<bool> OnUsed;

    public Action OnSetup;

    private bool used = false;

    public void Setup(GridElement associatedGridElement)
    {
        AssociatedGridElement = associatedGridElement;

        OnSetup?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (used == true)
            return;

        OnClicked?.Invoke(this);
    }

    public void UsePiece(bool onOff)
    {
        used = onOff;
        OnUsed?.Invoke(used);
    }
}
