using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    protected GridElement[] gridElements;

    private GridCoordinateValidator gridCoordinateValidator = new RealGridCoordinateValidator();

    public GridCoordinateValidator GridCoordinateValidator
    {
        get
        {
            return gridCoordinateValidator;
        }

        set
        {
            gridCoordinateValidator = value;
        }
    }

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

    public void AddElement(GridElement elementToAdd, int x, int y)
    {
        bool gridCoordinatesAreValid = gridCoordinateValidator.AreGridCoordinatesValid(height, width, x, y);

        if(gridCoordinatesAreValid == false)
        {
            throw new ArgumentException("Grid coordinates of elementToAdd are not valid");
        }

        if (CellIsEmpty(x, y) == false)
        {
            throw new ArgumentException("The target cell is not empty. You can only add an element to an empty cell.");
        }

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

    private bool CellIsEmpty(int x, int y)
    {
       GridElement element = GetElementFromGrid(x, y);

        return element == null;
    }

    private bool CanPlaceElementAtCoordinates(GridElement element, int x, int y)
    {
        // Based on the element's coordinates, check:
        // row
        // column
        // corner

        return true;
    }

    public GridElement[] GetRowFromCoordinatesOfGridElement(int x, int y)
    {
        if(gridCoordinateValidator.AreGridCoordinatesValid(height, width, x, y) == false)
        {
            throw new ArgumentException("The coordinates you input are out of the grid.");
        }

        GridElement[] result = new GridElement[4];

        for(int i = 0; i < 4; i++)
        {
            result[i] = GetElementFromGrid(i, y);
        }

        return result;
    }

    protected int GridCoordinateIndex(int x, int y)
    {
        return width * y + x;
    }
}
