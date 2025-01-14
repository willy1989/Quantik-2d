using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement
{
    public GridElementShape Shape { get; private set; }

    public GridElementColor Color { get; private set; }

    public GridElement()
    {

    }

    public GridElement(GridElementShape shape, GridElementColor color)
    {
        this.Shape = shape;
        this.Color = color;
    }

    public enum GridElementShape
    {
        Cube,
        Pyramid,
        Sphere,
        Cylinder
    }

    public enum GridElementColor
    {
        Black,
        White
    }
}
