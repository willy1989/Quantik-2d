using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGraphicsManager_TestHelper : GridGraphicsManager
{
    public Dictionary<GridElement, GameObject> GridElementGridGraphicsDictionary => gridElementGridGraphicsDictionary;

    public void AddPieceGraphics_UnitTest(GridElement gridElement, int x, int y)
    {
        AddPieceGraphics(gridElement, x, y);
    }

    public void PlacePieceGraphicsObject_UnitTest(GameObject pieceGraphicsObject, int x, int y)
    {
        PlacePieceGraphicsObject(pieceGraphicsObject, x, y);
    }
}
