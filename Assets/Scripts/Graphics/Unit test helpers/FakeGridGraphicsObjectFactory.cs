using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGridGraphicsObjectFactory : GridGraphicsObjectFactory
{
    public override GameObject CreatePieceGraphics(GridElement gridElement)
    {
        return new GameObject();
    }
}
