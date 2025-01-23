using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTile : MonoBehaviour
{
    public Vector2Int GridCoordinate { get; private set; }

    public void Setup(Vector2Int gridCoordinate)
    {
        GridCoordinate = gridCoordinate;
    }
}
