using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    private GridElementPatternManager gridPatternManager = new GridElementPatternManager();


    public int Width { get; private set; }
    public int Height { get; private set; }

    public Action<GridElement, int, int> OnGridElementAdded;
    public Action<GridElement> OnGridElementRemoved;

    public Grid(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        gridElements = new GridElement[width * height];
        GameLoopManager.OnResetGame += ResetState;
    }

    private void ResetState()
    {
        gridElements = new GridElement[Width * Height];
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
        bool gridCoordinatesAreValid = gridCoordinateValidator.AreGridCoordinatesValid(Height, Width, x, y);

        ValidateGridCoordinates(Width, Height, x, y);

        if (IsCellEmpty(x, y) == false)
        {
            throw new ArgumentException("The target cell is not empty. You can only add an element to an empty cell.");
        }

        gridElements[GridCoordinateIndex(x, y)] = elementToAdd;

        OnGridElementAdded?.Invoke(elementToAdd, x, y);
    }

    public void RemoveElement(int x, int y)
    {
        ValidateGridCoordinates(Width, Height, x, y);

        if (IsCellEmpty(x, y) == true)
        {
            throw new ArgumentException("The target cell is empty. There is nothing to remove.");
        }

        OnGridElementRemoved?.Invoke(GetElementFromGrid(x, y));

        gridElements[GridCoordinateIndex(x, y)] = null;
    }

    public GridElement GetElementFromGrid(int x, int y)
    {
        ValidateGridCoordinates(Width, Height, x, y);

        GridElement result = gridElements[GridCoordinateIndex(x, y)];

        return result;
    }

    public bool IsCellEmpty(int x, int y)
    {
        ValidateGridCoordinates(Width, Height, x, y);

        GridElement element = GetElementFromGrid(x, y);

        return element == null;
    }

    public GridElement[] GetRowFromCoordinatesOfGridElement(int x, int y)
    {
        ValidateGridCoordinates(Width, Height, x, y);

        GridElement[] result = new GridElement[4];

        for(int i = 0; i < 4; i++)
        {
            result[i] = GetElementFromGrid(i, y);
        }

        return result;
    }

    public GridElement[] GetColumnFromCoordinatesOfGridElement(int x, int y)
    {
        ValidateGridCoordinates(Width, Height, x, y);

        GridElement[] result = new GridElement[Height];

        for (int i = 0; i < Height; i++)
        {
            result[i] = GetElementFromGrid(x, i);
        }

        return result;
    }

    public GridElement[] GetCornerFromCoordinatesOfGridElement(int x, int y)
    {
        ValidateGridCoordinates(Width, Height, x, y);

        int startX = Mathf.FloorToInt(x/2) * 2;

        int startY = Mathf.FloorToInt(y/2) * 2;

        GridElement[] result = new GridElement[4]
        {
           GetElementFromGrid(startX, startY),
           GetElementFromGrid(startX + 1 ,startY),
           GetElementFromGrid(startX, startY + 1),
           GetElementFromGrid(startX + 1, startY + 1)
        };

        return result;
    }

    protected int GridCoordinateIndex(int x, int y)
    {
        return Width * y + x;
    }

    public bool IsRowLegal(int xGridCoordinate, int yGridCoordinate)
    {
        GridElement[] gridElements = GetRowFromCoordinatesOfGridElement(xGridCoordinate, yGridCoordinate);

        bool result = !gridPatternManager.TwoElementsOfSameShapeAndDifferentColors(gridElements);

        return result;
    }

    public bool IsColumnLegal(int xGridCoordinate, int yGridCoordinate)
    {
        GridElement[] gridElements = GetColumnFromCoordinatesOfGridElement(xGridCoordinate, yGridCoordinate);

        bool result = !gridPatternManager.TwoElementsOfSameShapeAndDifferentColors(gridElements);

        return result;
    }

    public bool IsCornerLegal(int xGridCoordinate, int yGridCoordinate)
    {
        GridElement[] gridElements = GetCornerFromCoordinatesOfGridElement(xGridCoordinate, yGridCoordinate);

        bool result = !gridPatternManager.TwoElementsOfSameShapeAndDifferentColors(gridElements);

        return result;
    }

    private void ValidateGridCoordinates(int height, int width, int x, int y)
    {
        if (gridCoordinateValidator.AreGridCoordinatesValid(height, width, x, y) == false)
        {
            throw new ArgumentException("The coordinates you input are out of the grid.");
        }
    }
}
