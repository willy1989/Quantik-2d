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

    public void PickUp()
    {
        OnPickedUp?.Invoke();
    }

    public void Drop()
    {
        OnDropped?.Invoke();
    }

    public void Place()
    {
        IsPlaced = true;
        OnPlaced?.Invoke();
    }
}
