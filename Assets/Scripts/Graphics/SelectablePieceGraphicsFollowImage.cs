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
        selectablePieceInteraction.OnClickedNoArgument += () => ToggleFollow(true);

        selectablePieceInteraction.OnPiecePlaced += () => ToggleFollow(false);
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

        Debug.Log("Mouse cursor position: " + mouseCursorPosition);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        Debug.Log("Local point: " + localPoint);

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
}
