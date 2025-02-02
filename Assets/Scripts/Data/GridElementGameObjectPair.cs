using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementGameObjectPair
{
    public GridElement GridElement { get; private set; }
    public GameObject GameObject { get; private set; }

    public GridElementGameObjectPair(GridElement gridElement, GameObject gameObject)
    {
        GridElement = gridElement;
        GameObject = gameObject;
    }
}
