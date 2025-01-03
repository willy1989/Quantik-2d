using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    protected GridElement[] gridElements;

    private GridCoordinateValidator gridCoordinateValidator;

    protected int width { get; private set; }
    protected int height { get; private set; }

    public Grid(int width, int height, GridCoordinateValidator gridCoordinateValidator)
    {
        this.width = width;
        this.height = height;

        gridElements = new GridElement[width * height];

        this.gridCoordinateValidator = gridCoordinateValidator;
    }

    public void PopulateGrid(GridElement[] newElements)
    {
        if(newElements.Length != this.gridElements.Length)
        {
            throw new ArgumentException("The quantity of newElements should match the quantity of gridElements set in the constructor. " +
                                        "You input " + newElements.Length.ToString() + " newElements, while the gridElements is " +  gridElements.Length.ToString()+" .");
        }

        for(int i = 0; i < newElements.Length; i++)
        {
            gridElements[i] = newElements[i];
        }
    }

    public void AddElement(GridElement elementToAdd, int x, int y)
    {
        // Check grid coordinates validity

        // Check whether there already is a element at the specified coordinates

        // Check whether the elementToAdd is null

        gridElements[GridCoordinateIndex(x, y)] = elementToAdd;
    }

    public GridElement GetElementFromGrid(int x, int y)
    {
        if(gridCoordinateValidator.AreGridCoordinatesValid(height, width, x, y) == false)
        {
            throw new ArgumentException("The x and y coordinates you specified are beyond the scope of the grid.");
        }

        GridElement result = gridElements[GridCoordinateIndex(x, y)];

        return result;
    }

    protected int GridCoordinateIndex(int x, int y)
    {
        return width * y + x;
    }
}
