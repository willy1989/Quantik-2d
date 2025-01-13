using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement
{
    private Shape shape;

    private Color color;

    public GridElement()
    {

    }

    public GridElement(Shape shape, Color color)
    {
        this.shape = shape;
        this.color = color;
    }

    public enum Shape
    {
        Cube,
        Pyramid,
        Sphere,
        Cylinder
    }

    public enum Color
    {
        Black,
        White
    }
}
