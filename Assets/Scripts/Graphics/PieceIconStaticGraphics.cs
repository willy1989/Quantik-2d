using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceIconStaticGraphics : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private SpriteGridGraphicsFactory spriteGridGraphicsFactory;

    public void SetPieceIcon(PieceIcon pieceIcon)
    {
        ToggleGraphics(false);
        if (pieceIcon.IsPlaced == true)
            return;

        ToggleGraphics(true);
        image.sprite = spriteGridGraphicsFactory.GetPieceSprite(pieceIcon.GetAssociatedGridElement());

        pieceIcon.OnPickedUp += () => ToggleGraphics(false);
        pieceIcon.OnPlaced += () => ToggleGraphics(false);
        pieceIcon.OnDropped += () => ToggleGraphics(true);
    }

    private void ToggleGraphics(bool onOff)
    {
        image.enabled = onOff;
    }
}
