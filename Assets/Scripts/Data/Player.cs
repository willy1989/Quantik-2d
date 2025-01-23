using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public List<GridElement.GridElementShape> StartingShapes { get; private set; } = new List<GridElement.GridElementShape>();

    public GridElement.GridElementColor ElementColor { get; private set; }

    private Grid grid;

    public Action OnPiecePlaced;

    public Player(GridElement.GridElementColor elementColor, Grid grid)
    {
        this.ElementColor = elementColor;

        this.grid = grid;

        GenerateStartingGridElements();
    }

    private void GenerateStartingGridElements()
    {
        List<GridElement> elements = new List<GridElement>();

        Array shapes = Enum.GetValues(typeof(GridElement.GridElementShape));

        foreach (GridElement.GridElementShape shape in shapes)
        {
            StartingShapes.Add(shape);
            StartingShapes.Add(shape);
        }
    }

    // To do: create unit test
    public void PlayPiece(GridElement.GridElementShape shape, int xGridCoordinate, int yGridCoordinate)
    {
        // Check whether the shape is still available
        bool isShapeAvailable = IsShapeAvailable(shape);

        if (isShapeAvailable == false)
            return;

        // Check whether the grid cell is empty or not

        bool cellIsEmpty = grid.IsCellEmpty(xGridCoordinate, yGridCoordinate);

        if (cellIsEmpty == false)
            return;

        // Temporarily add the element on the grid
        GridElement gridElement = new GridElement(shape, ElementColor);

        grid.AddElement(gridElement,xGridCoordinate, yGridCoordinate);

        // Check whether it is legal to add a piece there

        bool rowIsLegal = grid.IsRowLegal(xGridCoordinate, yGridCoordinate);

        bool columnIsLegal = grid.IsColumnLegal(xGridCoordinate, yGridCoordinate);

        bool cornerIsLegal = grid.IsCornerLegal(xGridCoordinate, yGridCoordinate);

        // Remove piece if the move was not legal

        if(rowIsLegal == false || columnIsLegal == false || cornerIsLegal == false)
        {
            grid.RemoveElement(xGridCoordinate, yGridCoordinate);
        }

        else
        {
            StartingShapes.RemoveAt(StartingShapes.IndexOf(shape));
            OnPiecePlaced?.Invoke();
        }
    }



    // To do: create unit test
    private bool IsShapeAvailable(GridElement.GridElementShape selectedShape)
    {
        return StartingShapes.Contains(selectedShape) == true;
    }


}
