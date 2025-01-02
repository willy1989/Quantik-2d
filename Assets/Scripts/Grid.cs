using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    protected GridElement[] gridElements;

    protected int width { get; private set; }
    protected int height { get; private set; }

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;

        gridElements = new GridElement[width * height];
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

    public void AddElement(GridElement element, int x, int y)
    {
        
    }

    public bool AreGridCoordinatesValid(int x, int y)
    {
        if (x < 0 || x > width - 1 || y < 0 || y > height - 1)
        {
            return false;
        }

        return true;
    }

    public GridElement GetElementFromGrid(int x, int y)
    {
        if(AreGridCoordinatesValid(x, y) == false)
        {
            throw new ArgumentException("The x and y coordinates you specified are beyond the scope of the grid.");
        }

        GridElement result = gridElements[width * y + x];

        return result;
    }
}
