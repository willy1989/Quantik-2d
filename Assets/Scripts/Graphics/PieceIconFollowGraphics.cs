using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceIconFollowGraphics : MonoBehaviour
{
    [SerializeField] private Image followImage;

    [SerializeField] private Canvas canvas;

    [SerializeField] private SpriteGridGraphicsFactory spriteGridGraphicsFactory;

    private bool canFollow = false;

    public void SetPieceIcon(PieceIcon pieceIcon)
    {
        pieceIcon.OnPickedUp += () => ToggleFollow(true);
        pieceIcon.OnPlaced += () => ToggleFollow(false);
        pieceIcon.OnDropped += () => ToggleFollow(false);
        followImage.sprite = spriteGridGraphicsFactory.GetPieceSprite(pieceIcon.GetAssociatedGridElement());
    }


    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        if (canFollow == false)
            return;

        Vector2 mouseCursorPosition = Input.mousePosition;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        followImage.rectTransform.anchoredPosition = localPoint;
    }

    private void ToggleFollow(bool onOff)
    {
        canFollow = onOff;
        followImage.enabled = onOff;
    }
}
