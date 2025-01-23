using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectablePieceGraphics : MonoBehaviour
{
    [SerializeField] private SelectablePiece selectablePiece;

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
        selectablePiece.OnUsed += ToggleGraphics;
    }

    private void SetSprite(GridElement gridElement)
    {
        sprite = spriteGridGraphicsFactory.GetPieceSprite(gridElement);

        image.sprite = sprite;
    }

    private void ToggleGraphics(bool onOff)
    {
        if (onOff == true)
            image.sprite = null;
        else
            image.sprite = sprite;
    }


}
