using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceIconStaticGraphics : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private SpriteGridGraphicsFactory spriteGridGraphicsFactory;

    private Sprite sprite;

    public void SetPieceIcon(PieceIcon pieceIcon)
    {
        if(pieceIcon.IsPlaced == false)
            SetSprite(pieceIcon.GetAssociatedGridElement());

        pieceIcon.OnPickedUp += () => ToggleGraphics(false);
        pieceIcon.OnPlaced += () => ToggleGraphics(false);
        pieceIcon.OnDropped += () => ToggleGraphics(true);
    }

    private void SetSprite(GridElement gridElement)
    {
        sprite = spriteGridGraphicsFactory.GetPieceSprite(gridElement);

        image.sprite = sprite;
    }

    private void ToggleGraphics(bool onOff)
    {
        if (onOff == false)
            image.sprite = null;
        else
            image.sprite = sprite;
    }
}
