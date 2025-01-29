using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PieceInteractionRaycaster : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster graphicRaycaster;

    [SerializeField] private EventSystem m_EventSystem;

    public PieceIconContainer GetPieceIconContainer()
    {
        //Set up the new Pointer Event
        PointerEventData m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        graphicRaycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            PieceIconContainer pieceIconContainer = result.gameObject.GetComponent<PieceIconContainer>();

            if (pieceIconContainer != null)
            {
                Debug.Log("Found piece icon container");
                return pieceIconContainer;
            }  
        }

        return null;
    }

    public PositionTile GetPositionTileFromMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject clickedObject = hit.collider.gameObject;

            PositionTile positionTile = clickedObject.GetComponent<PositionTile>();

            if (positionTile != null)
            {
                return positionTile;
            }
        }

        return null;
    }
}
