using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealGridGraphicsObjectFactory : GridGraphicsObjectFactory
{
    [SerializeField] private GameObject CubePiecePrefab;
    [SerializeField] private GameObject PyramidPiecePrefab;
    [SerializeField] private GameObject SpherePiecePrefab;
    [SerializeField] private GameObject CylinderPiecePrefab;

    public override GameObject CreatePieceGraphics(GridElement gridElement)
    {
        if (gridElement.Shape == GridElement.GridElementShape.Cube)
        {
            return Instantiate(original: CubePiecePrefab, parent: this.transform);
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Pyramid)
        {
            return Instantiate(original: PyramidPiecePrefab, parent: this.transform);
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Sphere)
        {
            return Instantiate(original: SpherePiecePrefab, parent: this.transform);
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Cylinder)
        {
            return Instantiate(original: CylinderPiecePrefab, parent: this.transform);
        }

        return null;
    }
}
