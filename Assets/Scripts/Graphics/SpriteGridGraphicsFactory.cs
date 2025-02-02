using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGridGraphicsFactory : MonoBehaviour
{
    [SerializeField] private Sprite whiteCubePieceSprite;
    [SerializeField] private Sprite whitePyramidPieceSprite;
    [SerializeField] private Sprite whiteSpherePieceSprite;
    [SerializeField] private Sprite whiteCylinderPieceSprite;

    [SerializeField] private Sprite blackCubePieceSprite;
    [SerializeField] private Sprite blackPyramidPieceSprite;
    [SerializeField] private Sprite blackSpherePieceSprite;
    [SerializeField] private Sprite blackCylinderPieceSprite;

    public Sprite GetPieceSprite(GridElement gridElement)
    {
        if (gridElement.Shape == GridElement.GridElementShape.Cube)
        {
            if(gridElement.Color == GridElement.GridElementColor.White)
                return whiteCubePieceSprite;
            else if (gridElement.Color == GridElement.GridElementColor.Black)
                return blackCubePieceSprite;
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Pyramid)
        {
            if (gridElement.Color == GridElement.GridElementColor.White)
                return whitePyramidPieceSprite;
            else if (gridElement.Color == GridElement.GridElementColor.Black)
                return blackPyramidPieceSprite;
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Sphere)
        {
            if (gridElement.Color == GridElement.GridElementColor.White)
                return whiteSpherePieceSprite;
            else if (gridElement.Color == GridElement.GridElementColor.Black)
                return blackSpherePieceSprite;
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Cylinder)
        {
            if (gridElement.Color == GridElement.GridElementColor.White)
                return whiteCylinderPieceSprite;
            else if (gridElement.Color == GridElement.GridElementColor.Black)
                return blackCylinderPieceSprite;
        }

        return null;
    }
}
