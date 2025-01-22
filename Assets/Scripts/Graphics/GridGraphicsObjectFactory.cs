using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridGraphicsObjectFactory : MonoBehaviour
{
    public abstract GameObject CreatePieceGraphics(GridElement gridElement);
}
