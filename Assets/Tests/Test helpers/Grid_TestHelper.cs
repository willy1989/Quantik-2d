using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_TestHelper : Grid
{
    public int Width => width;
    public int Height => height;

    public GridElement[] GridElements => gridElements;

    public Grid_TestHelper(int width, int height) : base(width, height)
    {
    }

    public int GridCoordinateIndex_UnitTest(int x, int y)
    {
        return GridCoordinateIndex(x, y);
    }
}
