using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowImageTest : MonoBehaviour
{
    [SerializeField] private Image followImage;

    [SerializeField] private Canvas canvas;

    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        Vector2 mouseCursorPosition = Input.mousePosition;

        Debug.Log("Mouse cursor position: " + mouseCursorPosition);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        Debug.Log("Local point: " +  localPoint);

        followImage.rectTransform.anchoredPosition = localPoint;
    }
}
