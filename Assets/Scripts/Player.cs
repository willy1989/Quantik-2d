using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    protected List<GridElement.GridElementShape> startingShapes { get; private set; } = new List<GridElement.GridElementShape>();

    protected GridElement.GridElementColor elementColor { get; private set; }

    private Grid grid;

    public Player(GridElement.GridElementColor elementColor, Grid grid)
    {
        this.elementColor = elementColor;

        this.grid = grid;

        GenerateStartingGridElements();
    }

    private void GenerateStartingGridElements()
    {
        List<GridElement> elements = new List<GridElement>();

        Array shapes = Enum.GetValues(typeof(GridElement.GridElementShape));

        foreach (GridElement.GridElementShape shape in shapes)
        {
            startingShapes.Add(shape);
            startingShapes.Add(shape);
        }
    }

    // To do: create unit test
    public void PlayPiece(GridElement.GridElementShape shape, int xGridCoordinate, int yGridCoordinate)
    {
        // Check whether the shape is still available
        bool isShapeAvailable = IsShapeAvailable(shape);

        if (isShapeAvailable == false)
            return;

        startingShapes.RemoveAt(startingShapes.IndexOf(shape));

        // Check whether the grid cell is empty or not

        bool cellIsEmpty = grid.IsCellEmpty(xGridCoordinate, yGridCoordinate);

        if (cellIsEmpty == false)
            return;

        // Temporarily add the element on the grid
        GridElement gridElement = new GridElement(shape, elementColor);

        grid.AddElement(gridElement,xGridCoordinate, yGridCoordinate);

        // Check whether it is legal to add a piece there
    }



    // To do: create unit test
    private bool IsShapeAvailable(GridElement.GridElementShape selectedShape)
    {
        return startingShapes.Contains(selectedShape) == true;
    }


}
