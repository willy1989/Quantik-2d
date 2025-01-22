using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTile : MonoBehaviour
{
    public Vector2 GridCoordinate { get; private set; }

    public void Setup(Vector2 gridCoordinate)
    {
        GridCoordinate = gridCoordinate;
    }
}
