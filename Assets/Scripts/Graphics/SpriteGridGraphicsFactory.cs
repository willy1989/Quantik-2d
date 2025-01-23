using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGridGraphicsFactory : MonoBehaviour
{
    [SerializeField] private Sprite CubePieceSprite;
    [SerializeField] private Sprite PyramidPieceSprite;
    [SerializeField] private Sprite SpherePieceSprite;
    [SerializeField] private Sprite CylinderPieceSprite;

    public Sprite GetPieceSprite(GridElement gridElement)
    {
        if (gridElement.Shape == GridElement.GridElementShape.Cube)
        {
            return CubePieceSprite;
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Pyramid)
        {
            return PyramidPieceSprite;
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Sphere)
        {
            return SpherePieceSprite;
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Cylinder)
        {
            return CylinderPieceSprite;
        }

        return null;
    }
}
