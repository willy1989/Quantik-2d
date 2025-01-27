using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectablePieceGraphicsFollowImage : MonoBehaviour
{
    [SerializeField] private Image followImage;

    [SerializeField] private Canvas canvas;

    [SerializeField] private SelectablePieceInteraction selectablePieceInteraction;

    [SerializeField] private SpriteGridGraphicsFactory spriteGridGraphicsFactory;

    private bool canFollow = false;

    private void Awake()
    {
        followImage.enabled = false;
        selectablePieceInteraction.OnPiecePickedUp += ToggleFollowON;
        selectablePieceInteraction.OnIsSelectableOn += ToggleFollowOFF;
        selectablePieceInteraction.OnIsSelectableOff += ToggleFollowOFF;
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

        if(onOff == true)
        {
            followImage.sprite = spriteGridGraphicsFactory.GetPieceSprite(selectablePieceInteraction.AssociatedGridElement);
        }
    }

    private void ToggleFollowON(SelectablePieceInteraction selectablePieceInteraction)
    {
        ToggleFollow(true);
    }

    private void ToggleFollowOFF()
    {
        ToggleFollow(false);
    }
}
