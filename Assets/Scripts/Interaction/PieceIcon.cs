using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIcon : MonoBehaviour
{
    [SerializeField] private GridElement associatedGridElement;

    public Action OnPickedUp;
    public Action OnDropped;
    public Action OnPlaced;

    public Action OnSetup;

    public bool IsPickedUp { get; private set; } = false;
    public bool IsDropped { get; private set; } = false;

    public bool IsPlaced { get; private set; } = false;

    public void Setup(GridElement associatedGridElement)
    {
        this.associatedGridElement = associatedGridElement;
        OnSetup?.Invoke();
    }

    public GridElement GetAssociatedGridElement()
    {
        return associatedGridElement;
    }

    public void PickUp(bool value)
    {
        IsPickedUp = value;

        if(IsPickedUp == true)
        {
            OnPickedUp?.Invoke();
        }
    }

    public void Drop(bool value)
    {
        IsDropped = value;

        if (IsDropped == true)
        {
            OnDropped?.Invoke();
        }
        
    }

    public void Place(bool value)
    {
        IsPlaced = value;

        if (IsPlaced == true)
        {
            OnPlaced?.Invoke();
        }
        
    }
}
