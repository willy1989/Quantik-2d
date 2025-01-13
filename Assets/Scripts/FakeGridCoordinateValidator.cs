using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGridCoordinateValidator : GridCoordinateValidator
{
    private bool gridCoordinatesAreValid;

    public bool GridCoordinatesAreValid
    {
        set
        {
            gridCoordinatesAreValid = value;
        }
    }

    public bool AreGridCoordinatesValid(int height, int width, int x, int y)
    {
        return gridCoordinatesAreValid;
    }
}
