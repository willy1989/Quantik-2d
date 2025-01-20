using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealGridCoordinateValidator : GridCoordinateValidator
{
    public bool AreGridCoordinatesValid(int height, int width, int x, int y)
    {
        if (x < 0 || x > width - 1 || y < 0 || y > height - 1)
        {
            return false;
        }

        return true;
    }
}
