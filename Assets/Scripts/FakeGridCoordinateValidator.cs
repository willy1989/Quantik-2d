using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGridCoordinateValidator : GridCoordinateValidator
{
    public bool AreGridCoordinatesValid(int height, int width, int x, int y)
    {
        return true;
    }
}
