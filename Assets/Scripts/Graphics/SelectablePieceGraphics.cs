using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectablePieceGraphics : MonoBehaviour
{
    [SerializeField] private SelectablePieceInteraction selectablePiece;

    [SerializeField] private Image image;

    [SerializeField] private SpriteGridGraphicsFactory spriteGridGraphicsFactory;

    private Sprite sprite; 

    private void Awake()
    {
        selectablePiece.OnSetup += Setup;
    }

    private void Setup()
    {
        SetSprite(selectablePiece.AssociatedGridElement);
        selectablePiece.OnPiecePickedUp += ToggleGraphicsOFF;
        selectablePiece.OnIsSelectableOn += ToggleGraphicsON;
    }

    private void SetSprite(GridElement gridElement)
    {
        sprite = spriteGridGraphicsFactory.GetPieceSprite(gridElement);

        image.sprite = sprite;
    }

    private void ToggleGraphicsOFF(SelectablePieceInteraction selectablePieceInteraction)
    {
        ToggleGraphics(false);
    }

    private void ToggleGraphicsON()
    {
        ToggleGraphics(true);
    }

    private void ToggleGraphics(bool onOff)
    {
        if (onOff == false)
            image.sprite = null;
        else
            image.sprite = sprite;
    }
}
