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

    private Dictionary<(GridElement.GridElementShape, GridElement.GridElementColor), Sprite> spriteDictionary;

    private void Awake()
    {
        spriteDictionary = new Dictionary<(GridElement.GridElementShape, GridElement.GridElementColor), Sprite>
        {
            { (GridElement.GridElementShape.Cube, GridElement.GridElementColor.White), whiteCubePieceSprite },
            { (GridElement.GridElementShape.Cube, GridElement.GridElementColor.Black), blackCubePieceSprite },

            { (GridElement.GridElementShape.Pyramid, GridElement.GridElementColor.White), whitePyramidPieceSprite },
            { (GridElement.GridElementShape.Pyramid, GridElement.GridElementColor.Black), blackPyramidPieceSprite },

            { (GridElement.GridElementShape.Sphere, GridElement.GridElementColor.White), whiteSpherePieceSprite },
            { (GridElement.GridElementShape.Sphere, GridElement.GridElementColor.Black), blackSpherePieceSprite },

            { (GridElement.GridElementShape.Cylinder, GridElement.GridElementColor.White), whiteCylinderPieceSprite },
            { (GridElement.GridElementShape.Cylinder, GridElement.GridElementColor.Black), blackCylinderPieceSprite }
        };
    }

    public Sprite GetPieceSprite(GridElement gridElement)
    {
        return spriteDictionary.TryGetValue((gridElement.Shape, gridElement.Color), out var sprite) ? sprite : null;
    }
}