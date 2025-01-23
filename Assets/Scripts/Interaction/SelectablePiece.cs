using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectablePiece : MonoBehaviour, IPointerClickHandler
{
    public Action<SelectablePiece> OnClicked;

    private bool used = false;

    public GridElement AssociatedGridElement { get; private set; }

    public Action<bool> OnUsed;

    public Action OnSetup;

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
