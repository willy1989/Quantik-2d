using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GridCoordinateValidator
{
    public bool AreGridCoordinatesValid(int height, int width, int x, int y);
}
